using HtmlAgilityPack;
using log4net;
using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace instagramCrwaling.cs
{
    public partial class Form1 : Form
    {

        #region user32dll import
        const int KEYEVENTF_KEYDOWN = 0x00;
        const int KEYEVENTF_KEYUP = 0x02;

        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        static extern void keybd_event(byte vk, byte scan, int flags, int extra);

        [Flags]
        public enum KeyFlag
        {
            /// <summary>
            /// 키 누름
            /// </summary>
            KE_DOWN = 0,
            /// <summary>
            /// 확장 키
            /// </summary>
            KE__EXTENDEDKEY = 1,
            /// <summary>
            /// 키 뗌
            /// </summary>
            KE_UP = 2
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        string[] chosungString = new string[] { "r", "R", "s", "e", "E", "f", "a", "q", "Q", "t", "T", "d", "w", "W", "c", "z", "x", "v", "g" };
        string[] joongsungString = new string[] { "k","o","i","O","j","p","u","P","h","hk","ho","hl","y","n","nj","np","nl"
             ,"b","m","ml","l"};
        string[] jongsungString = new string[]{ " ","r", "R","rt","s","sw","sg","e","f","fr","fa","fq","ft","fx","fv","fg","a","q",
         "qt","t","T","d","w","c","z","x","v","g"};

        #endregion

        #region 일반 변수 선언
        InternetExplorer ie = null;
        SHDocVw.WebBrowser webBrowser = null;
        HtmlAgilityPack.HtmlDocument document;
        HtmlNodeCollection nodes;

        int indexNum = 0;
        int macroListTextboxCursor = 0;
        int nextRowIndex = 0;
        string indexString = String.Empty;
        string checkString = String.Empty;
        string macroString = String.Empty;
        string macroList = String.Empty;
        string prevUrl = String.Empty;

        private Stopwatch totalsw = null;
        Microsoft.Win32.RegistryKey rk = null;
        System.Timers.Timer mouseDetectTimer = null; //좌표 감지에 쓰이는 타이머
        Random random = null;
        private ILog log = LogManager.GetLogger("Program");
        BackgroundWorker worker = null;

        static string initial_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = initial_path + "//성공한ID목록.txt";
        #endregion

        #region 변수 재활용
        private Stopwatch setTotalSw()
        {
            if (totalsw == null)
                totalsw = new Stopwatch();
            totalsw.Reset();
            return totalsw;
        }
        private Random setRandomInstance()
        {
            if (random == null)
                random = new Random(Guid.NewGuid().GetHashCode());
            return random;
        }
        private System.Timers.Timer setTimer()
        {
            if (mouseDetectTimer == null)
                mouseDetectTimer = new System.Timers.Timer();
            return mouseDetectTimer;
        }
        #endregion

        #region 마우스 클릭 이벤트
        public void LeftDoubleClick(string xpos, string ypos)
        {
            Console.WriteLine("xpos :" + xpos + "  ypos: " + ypos);
            Cursor.Position = new Point(int.Parse(xpos), int.Parse(ypos));

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(150);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            Console.Write("leftmousedoubleclick success");

        }

        public void LeftOneClick(string xpos, string ypos)
        {
            Cursor.Position = new Point(int.Parse(xpos), int.Parse(ypos));
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        }
        #endregion

        #region 체류시간 설정
        private void sleep(int s, int e)
        {
            random = setRandomInstance();
            int randomSecond = random.Next(s, e);
            Thread.Sleep(randomSecond * 1000);
            return;
        }
        #endregion

        //마지막 탭으로 ie 변경
        private void changeIeTab()
        {
            // Console.WriteLine("changeIeTab 시작");
            log.Debug("changeIeTab Start");
            ShellWindows allBrowsers = new ShellWindows();
            for (int i = allBrowsers.Count - 1; i >= 0; i--)
            {
                if (allBrowsers.Item(i) != null && !string.IsNullOrEmpty(((SHDocVw.InternetExplorer)allBrowsers.Item(i)).LocationURL))
                {
                    ie = (InternetExplorer)allBrowsers.Item(i);
                    webBrowser = (SHDocVw.WebBrowser)ie;
                    ie.Wait();
                    //   Console.WriteLine("changeIeTab 끝");
                    log.Debug("changeIeTab End");
                    return;
                }
            }
            log.Debug("changeIeTab 반환없이 End");
        }

        //첫번째 _8-yf5가 좋아요, 두번째가 댓글달기.

        //좋아요 버튼 클릭
        private void likeButton()
        {
            log.Debug("likeButton method start");
            mshtml.HTMLDocument document = ie.Document;
            var svgs = document.getElementsByTagName("svg");
            foreach (IHTMLElement svg in svgs)
            {
                string svgClassName = svg.className.Trim();

                if (svgClassName != null && svgClassName.Equals("_8-yf5"))
                {
                    svg.click();
                    log.Debug("likeButton method end");
                    return;
                }
            }


        }

        //댓글 버튼 클릭
        private void replyButton()
        {
            mshtml.HTMLDocument document = ie.Document;
            var svgs = document.getElementsByTagName("svg");
            int count = 0;
            foreach (IHTMLElement svg in svgs)
            {

                string svgClassName = svg.className.Trim();

                if (svgClassName != null && svgClassName.Equals("_8-yf5"))
                {
                    if (count == 1)
                    {
                        svg.click();
                        return;
                    }
                }
                count++;
            }
        }

        //댓글 작성
        private void writeReply(string fileName)
        {
            Thread.Sleep(3000);
            string[] allLines = File.ReadAllLines(@fileName);
            int length = allLines.Length;
            random = setRandomInstance();
            int randomChoice = random.Next(0, length);
            string line = allLines[randomChoice];
            line.Trim();
            inputString(line);


        }


        public Form1()
        {
            InitializeComponent();
            deleteAllIeProcesses();
        }

        public int getRandomIndex(int elementsLength)
        {
            random = setRandomInstance();
            int randomIndex = random.Next(0, elementsLength);
            return randomIndex;
        }

        #region BackgroundWorker event define

        bool checkRegex(string checkString, string pattern)
        {
            return Regex.IsMatch(checkString, pattern);
        }

        void bw_DoWork(List<string> splitMacroList, int macroListLength, DoWorkEventArgs e)
        {

            rk =
          Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\5.0\User Agent", true);

            if (radioButton2.Checked == true)
            {
                //"Mozilla/5.0 (Linux; Android 10.0.0; SGH-i907) AppleWebKit/664.76 (KHTML, like Gecko) Chrome/87.0.3131.15 Mobile Safari/664.76 
                //"Mozilla /5.0(Linux; U; Android 7.0.0; SGH-i907) AppleWebKit / 533.1(KHTML, like Gecko) Version / 4.0 Mobile Safari/ 533.1 Chrome/87.0.3131.15"
                rk.SetValue(null, "Mozilla/5.0 (Linux; Android 10.0.0; SGH-i907) AppleWebKit/664.76 (KHTML, like Gecko) Chrome/87.0.3131.15 Mobile Safari/664.76");
                if (rk != null)
                {
                    log.Debug("레지스트리 수정 완료");

                };
            }
            else
                rk.SetValue(null, "");

            while (true)

            {
                if (nextRowIndex == dataGridView1.RowCount)
                {
                    worker.CancelAsync();
                }
                totalsw = setTotalSw();
                totalsw.Start();

                log.Debug("\n\n\n매크로 작업목록 출력");
                foreach (string temp in splitMacroList)
                {
                    log.Debug(temp);
                }
                log.Debug("----------------------------------------------------\n\n");

                for (int i = 0; i < macroListLength; i++)
                {
                    //취소버튼 클릭시
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        totalsw.Stop();
                        return;
                    }


                    macroString = splitMacroList[i].Trim().Substring(1); //특수문자 제거
                    printCurrentMacro(macroString, i); //현재 명령을 라벨에 출력

                    indexNum = macroString[0] - '0';
                    indexString = macroString.Substring(macroString.IndexOf(".") + 1, macroString.IndexOf("=") - (macroString.IndexOf(".") + 1));

                    string pattern = @"^" + indexNum.ToString() + @"." + Regex.Escape(indexString) + @"$";
                    checkString = macroString.Substring(0, macroString.IndexOf("=")); //0.이동

                    //dot pattern 때문에 고생함
                    if (checkRegex(checkString, pattern))
                    {
                        log.Debug("현재 반복문 넘버 : " + i + " , 작업 이름: " + macroString);
                        try
                        {

                            switch (indexNum)
                            {
                                case 0:
                                    //접속방식 : pc버전 / mobile버전

                                    break;
                                case 1:
                                    //url 접속 또는 이동
                                    string url = checkUrl(macroString.Substring(macroString.IndexOf("=") + 1));
                                    makeIeProcess(url);
                                    break;

                                case 2:
                                    //검색 기록 삭제
                                    clearHistory();
                                    break;

                                case 3:
                                    //로그인
                                    loginMethod();
                                    nextRowIndex++;

                                    break;

                                case 4:
                                    //로그인버튼클릭
                                    loginButtonClick();

                                    changeIeTab();
                                    break;
                                case 5:
                                    //체류시간추가=30~50
                                    string st = macroString.Substring(macroString.IndexOf("=") + 1, macroString.IndexOf("~") - (macroString.IndexOf("=") + 1));
                                    int start_time = Int32.Parse(st);

                                    string et = macroString.Substring(macroString.IndexOf("~") + 1, (macroString.Length - 1) - macroString.IndexOf("~"));
                                    int end_time = Int32.Parse(et);

                                    sleep(start_time, end_time);
                                    break;
                                case 6:
                                    //마우스이벤트=왼쪽버튼 (더블)클릭:(100,300)
                                    string leftOrRight = macroString.Substring(macroString.IndexOf("=") + 1, macroString.IndexOf(" ") - (macroString.IndexOf("=") + 1));

                                    string clickOrDoubleClick = macroString.Substring(macroString.IndexOf(" ") + 1, macroString.IndexOf(":") - (macroString.IndexOf(" ") + 1));

                                    string xpos = macroString.Substring(macroString.IndexOf("(") + 1, macroString.IndexOf(",") - (macroString.IndexOf("(") + 1));
                                    string ypos = macroString.Substring(macroString.IndexOf(",") + 1, macroString.IndexOf(")") - (macroString.IndexOf(",") + 1));

                                    if (clickOrDoubleClick.StartsWith("더블"))
                                    {
                                        LeftDoubleClick(xpos, ypos);
                                    }
                                    else
                                    {
                                        LeftOneClick(xpos, ypos);
                                    }
                                    break;
                                case 7:
                                    //좋아요버튼클릭
                                    likeButton();
                                    break;
                                case 8:
                                    //팔로우버튼클릭
                                    findByKeyword("팔로우");
                                    break;
                                case 9:

                                    string fileName = macroString.Substring(macroString.IndexOf("=") + 1).Trim();
                                    Console.WriteLine(fileName);
                                    replyButton();
                                    writeReply(fileName);
                                    findByKeyword("게시");
                                    //메소드 들어와야함
                                    break;
                                default:
                                    Console.WriteLine("매크로형식이 맞지 않음");
                                    break;
                            }

                            //switch문 종료
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            log.Debug(ex);
                        }
                        finally
                        {
                            endCurrentMacro(macroString, i);
                        }
                    }
                    else
                    {
                        //regex가 맞지 않을때
                        //작업명령 format이 이상함.
                        continue;
                    }


                }
                splitInfiniteLoop(); // while문 반복마다 한번씩 실행됨 
                //deleteAllTab();
                ie = null;
                deleteAllIeProcesses();
                totalsw.Stop();

            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;

            reportTextBox.Text += endAllMacro(ref totalsw);

            reportTextBox.SelectionStart = reportTextBox.TextLength;
            reportTextBox.ScrollToCaret();

            currentMacroLabel.Text = "현재 진행 명령 : 작업이 중단되었습니다.";

            processStartButton.Enabled = true;
            processStopButton.Enabled = true;
            if (e.Error != null)
            {
                reportTextBox.Text += "에러가 발생해서 작업이 중단되었습니다." + Environment.NewLine;
            }
            reportTextBox.Text += "작업을 중단했습니다." + Environment.NewLine;
            worker = null;
            deleteAllIeProcesses();

            ie = null;
            if (rk != null)
                rk.SetValue(null, "");

            //예외처리 필요?


        }
        #endregion

        //로그인 버튼 클릭
        public void loginButtonClick()
        {
            mshtml.HTMLDocument dd = ie.Document;
            var buttons = dd.getElementsByTagName("button");
            foreach (IHTMLElement button in buttons)
            {
                string buttonInnerHtml = button.innerText;

                if (buttonInnerHtml != null && buttonInnerHtml.Equals("로그인"))
                {
                    button.click();
                    return;
                }
            }
        }

        //해당 ID와 PW로 로그인하기
        public void loginMethod()
        {

            dataGridView1.ClearSelection();

            dataGridView1.Rows[nextRowIndex].Selected = true;

            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string pw = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            inputId(id);
            inputPassword(pw);

            mshtml.HTMLDocument dd = ie.Document;
            var divs = dd.getElementsByTagName("div");
            foreach (IHTMLElement div in divs)
            {
                string divInnterHtml = div.innerText;
                if (divInnterHtml != null && divInnterHtml.Equals("로그인"))
                {
                    Console.WriteLine("로그인 버튼 클릭");
                    div.click();

                    Thread.Sleep(5000);

                    mshtml.HTMLDocument dda = ie.Document;

                    var alertP = dda.getElementById("slfErrorAlert");

                    if (alertP == null)
                    {
                        //로그인 성공

                        FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                        string strData = id + " " + pw;
                        StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                        streamWriter.WriteLine(strData);
                        streamWriter.Close();

                        fileStream.Close();
                        return;

                    }
                    //else
                    //{
                    //    FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                    //    string strData = id + " " + pw;
                    //    StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                    //    streamWriter.WriteLine(strData);
                    //    streamWriter.Close();

                    //    fileStream.Close();
                    //    //로그인 실패
                    //    return;

                    //}
                }
            }

        }

        public void deleteAllIeProcesses()
        {
            Process[] IeProcesses = Process.GetProcessesByName("iexplore");
            foreach (var IeProcess in IeProcesses)
            {
                IeProcess.Kill();

            }
        }

        void findByKeyword(string keyword)
        {
            mshtml.HTMLDocument dd = ie.Document;
            var buttons = dd.getElementsByTagName("button");
            foreach (IHTMLElement button in buttons)
            {
                string buttonInnerHtml = button.innerText;
                if (buttonInnerHtml != null && buttonInnerHtml.Equals(keyword))
                {

                    button.click();
                    return;
                }
            }
        }


        #region 파일 관련 method
        private void replyFileOpenButton_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "txt";
            fileDialog.FileOk += checkFileName;
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1; //파일다이얼로그가 열릴 때 파일 유형을 어떤걸 선택할것인지. 2이므로 *.txt로 설정되어 있음
            fileDialog.RestoreDirectory = true;
            //set initial screen as desktop
            string initial_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.InitialDirectory = initial_path;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                replyFileNameTextBox.Text = fileName;
            }
        }

        void checkFileName(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog dlg = (sender as OpenFileDialog);
            if (Path.GetExtension(dlg.FileName).ToLower() != ".txt")
            {
                e.Cancel = true;
                MessageBox.Show(".txt 파일이 아닙니다.");
                return;
            }
        }

        private void fileOpenButton_Click(object sender, EventArgs e)
        {

            string fileName = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "txt";
            fileDialog.FileOk += checkFileName;
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1; //파일다이얼로그가 열릴 때 파일 유형을 어떤걸 선택할것인지. 2이므로 *.txt로 설정되어 있음
            fileDialog.RestoreDirectory = true;
            //set initial screen as desktop
            string initial_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.InitialDirectory = initial_path;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                fileNameTextbox.Text = fileName;

                string[] allLine = File.ReadAllLines(@fileName);
                int length = allLine.Length;
                int rowCount = 0;
                Console.WriteLine(length);

                dataGridView1.RowCount = length;

                foreach (string line in allLine)
                {
                    try
                    {
                        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                        dataGridView1.RowHeadersVisible = false;
                        dataGridView1.Rows[rowCount].Cells[0].Value = line.Substring(0, line.IndexOf(" "));
                        dataGridView1.Rows[rowCount].Cells[1].Value = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                        rowCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                nextRowIndex = 0;
                Console.WriteLine(dataGridView1.RowCount);

            }

        }
        #endregion

        #region 키보드 입력 부분
        private void inputId(string idString)
        {

            mshtml.HTMLDocument dd = ie.Document;
            var inputs = dd.getElementsByTagName("input");
            foreach (IHTMLElement input in inputs)
            {
                string inputName = input.getAttribute("name");

                //  if (inputName != null) Console.WriteLine("1" + inputName);
                if (!string.IsNullOrEmpty(inputName) && inputName.Equals("username"))
                {
                    ((IHTMLElement2)input).focus();

                    Thread.Sleep(1000);
                    break;
                }
            }

            inputString(idString);
            Thread.Sleep(1000);
            Console.WriteLine("inputID complete");
        }
        private void inputPassword(string pwString)
        {
            mshtml.HTMLDocument dd = ie.Document;
            var inputs = dd.getElementsByTagName("input");
            foreach (IHTMLElement input in inputs)
            {
                string inputName = input.getAttribute("name");
                if (!string.IsNullOrEmpty(inputName) && inputName.Equals("password"))
                {
                    ((IHTMLElement2)input).focus();
                    Thread.Sleep(1000);
                    //  ((IHTMLElement2)input).focus();
                    break;
                }
            }
            inputString(pwString);
            Thread.Sleep(1000);
        }

        private void inputHanguel(string inputString)
        {
            SetForegroundWindow((IntPtr)ie.HWND);
            int nHangleKey = (int)Keys.HangulMode; // (int)Keys.HangulMode;  // (int)Keys.ProcessKey
            keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYDOWN, 0);
            Thread.Sleep(30);
            keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(30);
            char[] idChars = inputString.ToCharArray();

            foreach (char idChar in idChars)
            {
                if (idChar >= 'a' && idChar <= 'z')
                {
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x00, 0);
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x02, 0);

                }
                else if (idChar >= 'A' && idChar <= 'Z')
                {
                    keybd_event((int)Keys.LShiftKey, 0x00, 0x00, 0);

                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x00, 0);
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x02, 0);

                    keybd_event((int)Keys.LShiftKey, 0x00, 0x02, 0);

                }
            }

            keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYDOWN, 0);
            Thread.Sleep(30);
            keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(30);

        }

        private void inputString(string inputString)
        {
            Console.WriteLine(inputString);
            char[] idChars = inputString.ToCharArray();
            SetForegroundWindow((IntPtr)ie.HWND);

            foreach (char idChar in idChars)
            {
                Console.WriteLine(idChar);
                if (char.GetUnicodeCategory(idChar) == System.Globalization.UnicodeCategory.OtherLetter)
                {                    //한글인경우
                    string hanguelString = makeHanguelString(idChar.ToString());
                    Console.WriteLine("한글 : " + idChar.ToString() + "  -> 알파벳 : " + hanguelString);
                    inputHanguel(hanguelString);
                    continue;

                }
                else if (idChar >= 'a' && idChar <= 'z')
                {
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x00, 0);
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x02, 0);

                }
                else if (idChar >= 'A' && idChar <= 'Z')
                {
                    keybd_event((int)Keys.LShiftKey, 0x00, 0x00, 0);

                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x00, 0);
                    keybd_event((byte)(char.ToUpper(idChar)), 0, 0x02, 0);

                    keybd_event((int)Keys.LShiftKey, 0x00, 0x02, 0);
                }
                else
                {
                    int nValue = 0;
                    bool bShift = false;
                    switch (idChar)
                    {
                        case '~': bShift = true; nValue = (int)Keys.Oemtilde; break;
                        case '_': bShift = true; nValue = (int)Keys.OemMinus; break;
                        case '+': bShift = true; nValue = (int)Keys.Oemplus; break;
                        case '{': bShift = true; nValue = (int)Keys.OemOpenBrackets; break;
                        case '}': bShift = true; nValue = (int)Keys.OemCloseBrackets; break;
                        case '|': bShift = true; nValue = (int)Keys.OemPipe; break;
                        case ':': bShift = true; nValue = (int)Keys.OemSemicolon; break;
                        case '"': bShift = true; nValue = (int)Keys.OemQuotes; break;
                        case '<': bShift = true; nValue = (int)Keys.Oemcomma; break;
                        case '>': bShift = true; nValue = (int)Keys.OemPeriod; break;
                        case '?': bShift = true; nValue = (int)Keys.OemQuestion; break;

                        case '!': bShift = true; nValue = (int)Keys.D1; break;
                        case '@': bShift = true; nValue = (int)Keys.D2; break;
                        case '#': bShift = true; nValue = (int)Keys.D3; break;
                        case '$': bShift = true; nValue = (int)Keys.D4; break;
                        case '%': bShift = true; nValue = (int)Keys.D5; break;
                        case '^': bShift = true; nValue = (int)Keys.D6; break;
                        case '&': bShift = true; nValue = (int)Keys.D7; break;
                        case '*': bShift = true; nValue = (int)Keys.D8; break;
                        case '(': bShift = true; nValue = (int)Keys.D9; break;
                        case ')': bShift = true; nValue = (int)Keys.D0; break;

                        case '`': bShift = false; nValue = (int)Keys.Oemtilde; break;
                        case '-': bShift = false; nValue = (int)Keys.OemMinus; break;
                        case '=': bShift = false; nValue = (int)Keys.Oemplus; break;
                        case '[': bShift = false; nValue = (int)Keys.OemOpenBrackets; break;
                        case ']': bShift = false; nValue = (int)Keys.OemCloseBrackets; break;
                        case '\\': bShift = false; nValue = (int)Keys.OemPipe; break;
                        case ';': bShift = false; nValue = (int)Keys.OemSemicolon; break;
                        case '\'': bShift = false; nValue = (int)Keys.OemQuotes; break;
                        case ',': bShift = false; nValue = (int)Keys.Oemcomma; break;
                        case '.': bShift = false; nValue = (int)Keys.OemPeriod; break;
                        case '/': bShift = false; nValue = (int)Keys.OemQuestion; break;

                        case '1': bShift = false; nValue = (int)Keys.D1; break;
                        case '2': bShift = false; nValue = (int)Keys.D2; break;
                        case '3': bShift = false; nValue = (int)Keys.D3; break;
                        case '4': bShift = false; nValue = (int)Keys.D4; break;
                        case '5': bShift = false; nValue = (int)Keys.D5; break;
                        case '6': bShift = false; nValue = (int)Keys.D6; break;
                        case '7': bShift = false; nValue = (int)Keys.D7; break;
                        case '8': bShift = false; nValue = (int)Keys.D8; break;
                        case '9': bShift = false; nValue = (int)Keys.D9; break;
                        case '0': bShift = false; nValue = (int)Keys.D0; break;

                        case ' ': bShift = false; nValue = (int)Keys.Space; break;
                        case '\x1b': bShift = false; nValue = (int)Keys.Escape; break;
                        case '\b': bShift = false; nValue = (int)Keys.Back; break;
                        case '\t': bShift = false; nValue = (int)Keys.Tab; break;
                        case '\a': bShift = false; nValue = (int)Keys.LineFeed; break;
                        case '\r': bShift = false; nValue = (int)Keys.Enter; break;

                        default:
                            bShift = false; nValue = 0; break;

                    }

                    if (nValue != 0)
                    {
                        // Caps Lock의 상태에 따른 대/소문자 처리
                        if (bShift)
                        {
                            keybd_event((int)Keys.LShiftKey, 0x00, KEYEVENTF_KEYDOWN, 0);
                            Thread.Sleep(30);
                        }

                        // Key 눌림 처리함.
                        //int nValue = Convert.ToInt32(chValue);
                        //int nValue = (int)Keys.Oemtilde;
                        keybd_event((byte)nValue, 0x00, KEYEVENTF_KEYDOWN, 0);
                        Thread.Sleep(30);
                        keybd_event((byte)nValue, 0x00, KEYEVENTF_KEYUP, 0);
                        Thread.Sleep(30);

                        // Caps Lock 상태를 회복함.
                        if (bShift)
                        {
                            keybd_event((int)Keys.LShiftKey, 0x00, KEYEVENTF_KEYUP, 0);
                            Thread.Sleep(30);
                        }
                    }
                }


            }
        }

        //string[] chosungString = new string[] { "r", "R", "s", "e", "E", "f", "a", "q", "Q", "t", "T", "d", "w", "W", "c", "z", "x", "v", "g" };

        private string makeHanguelString(string hanguel)
        {

            char[] uchars = hanguel.ToCharArray();
            int cn = uchars[0] - 0xAC00;
            int chosung = (int)(cn / (28 * 21));
            Console.WriteLine((int)uchars[0] + ", " + chosung);
            int joongsung = (int)((cn % (28 * 21)) / 28);
            int jongsung = (int)(cn % 28);

            string hanguelString = string.Empty;

            if (cn < 0)
            {
                //초성만 존재
                switch (uchars[0])
                {
                    case 'ㄱ': hanguelString = "r"; break;
                    case 'ㄲ': hanguelString = "R"; break;
                    case 'ㄴ': hanguelString = "s"; break;
                    case 'ㄷ': hanguelString = "e"; break;
                    case 'ㄸ': hanguelString = "E"; break;
                    case 'ㄹ': hanguelString = "f"; break;
                    case 'ㅁ': hanguelString = "a"; break;
                    case 'ㅂ': hanguelString = "q"; break;
                    case 'ㅃ': hanguelString = "Q"; break;
                    case 'ㅅ': hanguelString = "t"; break;
                    case 'ㅆ': hanguelString = "T"; break;
                    case 'ㅇ': hanguelString = "d"; break;
                    case 'ㅈ': hanguelString = "w"; break;
                    case 'ㅉ': hanguelString = "W"; break;
                    case 'ㅊ': hanguelString = "c"; break;
                    case 'ㅋ': hanguelString = "z"; break;
                    case 'ㅌ': hanguelString = "x"; break;
                    case 'ㅍ': hanguelString = "v"; break;
                    case 'ㅎ': hanguelString = "g"; break;

                }
            }
            else
                hanguelString = chosungString[chosung] + joongsungString[joongsung] + jongsungString[jongsung];

            return hanguelString;

        }
        #endregion

        //캐시 삭제
        public void clearHistory()
        {
            deleteAllTab();
            ie = null;

            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351").WaitForExit();
            Console.WriteLine("history clear");
            log.Debug("캐시 삭제 완료");
        }

        //모든 탭 제거
        private void deleteAllTab()
        {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            foreach (InternetExplorer iea in shellWindows)
            {

                iea.Quit();
            }
        }


        //ie 프로세스 생성
        private void makeIeProcess(string url)
        {
            /*
             * have to check resolution
             * basic resolution : 800 x 600 
             * */
            url = checkUrl(macroString.Substring(macroString.IndexOf("=") + 1));
            Console.WriteLine(url);
            if (ie == null)
            {
                ie = new InternetExplorer();
                webBrowser = (SHDocVw.WebBrowser)ie;
                webBrowser.Visible = true;
                ie.Left = 0;
                ie.Top = 0;
                ie.Height = int.Parse(browserXSizeTextbox.Text);
                ie.Width = int.Parse(browserYSizeTextbox.Text);


            }
            //User-Agent: Mozilla / 5.0(Linux; U; Android 2.2) AppleWebKit / 533.1(KHTML, like Gecko) Version / 4.0 Mobile Safari/ 533.1"
            // "User-Agent: Mozilla/7.0(Linux; Android 7.0.0; SGH-i907) AppleWebKit/664.76 (KHTML, like Gecko) Chrome/87.0.3131.15 Mobile Safari/664.76 (Windows NT 10.0; WOW64; Trident/7.0; Touch; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; Tablet PC 2.0; rv:11.0) like Gecko"

            log.Debug("navigate2 start");
            ie.Navigate2(url, null, null, null, null);

            log.Debug("navigate2 complete");
            ie.Wait();
            prevUrl = url;
            log.Debug("wait complete");

        }

        private string checkUrl(string macroString)
        {

            bool includeHttps = macroString.StartsWith("http");
            if (includeHttps == false)
            {
                bool includeHttp = macroString.StartsWith("http");

                return "http://" + macroString;
            }
            else
            {
                return macroString;
            }
        }

        #region 마우스 좌표탐지
        //실시간 좌표 감지 시작
        private void mouseDetectStart(object sender, EventArgs e)
        {
            mouseDetectTimer = setTimer();
            mouseDetectTimer.Elapsed += timer_Elapsed;
            mouseDetectTimer.Start();
        }
        //실시간 좌표 감지 종료
        private void mouseDetectStop(object sender, EventArgs e)
        {
            mouseDetectTimer.Stop();
            mouseDetectTimer.Dispose();
            mouseDetectTimer = null;
        }
        delegate void TimerEventFiredDelegate();
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new TimerEventFiredDelegate(Work));
        }
        private void Work()
        {
            xAbsLocLabel.Text = "X=" + Cursor.Position.X.ToString();
            yAbsLocLabel.Text = "Y= " + Cursor.Position.Y.ToString();
            //수행해야할 작업(UI Thread 핸들링 가능)
        }
        #endregion

        #region ui변경 methods
        //해상도 적용 버튼 이벤트
        private void browserSizeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("해상도 적용 완료 : " + browserXSizeTextbox.Text + " X " + browserYSizeTextbox.Text);
        }

        private void processStopButton_Click(object sender, EventArgs e)
        {
            currentMacroLabel.Text = "현재 진행 명령 : 작업을 중단 중입니다. 현재 명령까지 실행함.";

            processStopButton.Enabled = false;

            worker.CancelAsync();

        }

        private void processStartButton_Click(object sender, EventArgs e)
        {
            macroList = String.Empty;
            macroList = macroListTextBox.Text;
            List<string> splitMacroList = new List<string>(macroList.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            int macroListLength = splitMacroList.Count;

            //작업 명령이 하나도 입력되지 않았을 때
            if (macroListLength == 0)
            {
                MessageBox.Show("작업 명령이 작성되지 않았습니다..");
                return;
            }

            log.Debug("\n\n\n");

            processStartButton.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;

            worker = new BackgroundWorker();
            worker.DoWork += (obj, ev) => bw_DoWork(splitMacroList, macroListLength, ev);
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += bw_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }


        private void macroListClearButton_Click(object sender, EventArgs e)
        {
            macroListTextBox.Clear();
        }

        //vmware같은곳에서는 사용할 수 없음. ip address 얻어옴.
        private IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        //보고서 textbox에 쓸 함수 구현, runworkerCompleted에서 사용됨
        private StringBuilder endAllMacro(ref Stopwatch sw)
        {
            StringBuilder successString = new StringBuilder();
            /*
             * 현재 IP : ipv4 string
             * 작업한 시간: HH:MM:SS.mmmm
             * 작업 완료 시간: 2019/12/12 12:24:19 AM/PM, macroString
             * 작업완료.
             */
            successString.AppendLine("현재 IP: " + LocalIPAddress());
            successString.AppendLine("작업한 시간: " + sw.Elapsed);
            string cntTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt, ");
            successString.AppendLine("작업 완료 시간: " + cntTime);
            successString.AppendLine("작업 완료");
            return successString;
        }

        //현재 매크로가 시작
        private void printCurrentMacro(string macroString, int num)
        {
            if (currentMacroLabel.InvokeRequired)
            {
                currentMacroLabel.BeginInvoke(new Action(() => { currentMacroLabel.Text = num + " , " + "현재 진행 명령 : " + macroString; }));
                return;
            }
        }

        //현재 매크로 완료
        private void endCurrentMacro(string macroString, int num)
        {
            if (reportTextBox.InvokeRequired)
            {
                reportTextBox.BeginInvoke(new Action(() =>
                {
                    reportTextBox.Text += num + " , " + "작업완료 : " + macroString.Substring(macroString.IndexOf(".") + 1) + "\r\n";

                    reportTextBox.SelectionStart = reportTextBox.TextLength;
                    reportTextBox.ScrollToCaret();

                    int pos = macroListTextBox.GetFirstCharIndexFromLine(macroListTextboxCursor);

                    if (pos > -1)
                    {
                        macroListTextBox.Select(pos, 0);
                        macroListTextBox.ScrollToCaret();
                    }
                    macroListTextboxCursor++;

                }));
                return;
            }
        }

        //무한 반복문에서 경계문으로 사용
        private void splitInfiniteLoop()
        {
            if (reportTextBox.InvokeRequired)
            {
                reportTextBox.BeginInvoke(new Action(() =>
                {
                    reportTextBox.Text += "-------------------------------------------"
+ Environment.NewLine;
                    reportTextBox.SelectionStart = reportTextBox.TextLength;
                    reportTextBox.ScrollToCaret();
                    macroListTextboxCursor = 0;
                }));
            }
        }

        //매크로 추가 버튼
        private void addMacroButton_Click(object sender, EventArgs e)
        {
            string macroString = String.Empty;
            int selectedIndex = tabControl1.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    //버전
                    break;
                case 1:
                    //url 이동
                    macroString = "▶" + selectedIndex + ".이동=" + inputUrlTextbox.Text;
                    break;
                case 2:
                    //검색기록삭제
                    macroString = "▶" + selectedIndex + ".검색기록삭제=";
                    break;
                case 3:
                    macroString = "▶" + selectedIndex + ".로그인명령=";
                    break;
                case 4:
                    macroString = "▶" + selectedIndex + ".로그인버튼클릭=";
                    break;
                case 5:
                    //체류시간 설정
                    if (sleepStartTextBox.Text == "" || sleepEndTextBox.Text == "")
                    {
                        MessageBox.Show("체류 시간을 입력하세요.");
                    }
                    else
                    {
                        macroString = "▶" + selectedIndex + ".체류시간추가=" + sleepStartTextBox.Text + "~" + sleepEndTextBox.Text;
                    }
                    break;
                case 6:
                    if (mouseEventComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("이벤트를 선택해주세요.");
                    }
                    else
                    {
                        //마우스이벤트=왼쪽/오른쪽 클릭:(100,300)
                        if (xAbsLocTextBox.Text.Length == 0 || yAbsLocTextBox.Text.Length == 0)
                        {
                            MessageBox.Show("X좌표와 Y좌표를 입력해주세요.");
                        }
                        else
                        {
                            macroString = "▶" + selectedIndex + ".마우스이벤트=" + mouseEventComboBox.Text + ":(" +
                                xAbsLocTextBox.Text + "," + yAbsLocTextBox.Text + ")";
                        }
                    }
                    break;
                case 7:
                    macroString = "▶" + selectedIndex + ".좋아요버튼클릭=";
                    break;
                case 8:
                    macroString = "▶" + selectedIndex + ".팔로우버튼클릭=";
                    break;
                case 9:
                    if (replyFileNameTextBox.Text == "")
                    {
                        MessageBox.Show("파일을 선택해야 합니다.");
                    }
                    else
                    {
                        macroString = "▶" + selectedIndex + ".댓글 게시하기=" + replyFileNameTextBox.Text;
                    }
                    break;


            }
            macroListTextBox.Text += macroString + "\r\n";
        }

        private void urlClearButton_Click(object sender, EventArgs e)
        {
            inputUrlTextbox.Clear();
        }


        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            //makeHanguelString("ㅎ");
            inputString("빨로우ㅎㅁㅂㅈㄷㄱ");
            //string str = "환";
            //char[] uchars = str.ToCharArray();
            //int cn = uchars[0] - 0xAC00;
            //int chosung = (int)(cn / (28 * 21));
            //int joongsung = (int)((cn % (28 * 21)) / 28);
            //int jongsung = (int)(cn % 28);

            //Console.WriteLine(chosungString[chosung]);
            //Console.WriteLine(joongsungString[joongsung]);
            //Console.WriteLine(jongsungString[jongsung]);

            //string hanguel = "ghks";
            //int nHangleKey = (int)Keys.HangulMode; // (int)Keys.HangulMode;  // (int)Keys.ProcessKey

            //textBox1.Focus();
            //Thread.Sleep(300);
            //keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYDOWN, 0);
            //Thread.Sleep(300);

            //keybd_event((byte)nHangleKey, 0x00, KEYEVENTF_KEYUP, 0);
            //Thread.Sleep(300);
            //keybd_event((byte)Keys.G, 0x00, KEYEVENTF_KEYDOWN, 0);
            //keybd_event((byte)Keys.G, 0x00, KEYEVENTF_KEYUP, 0);

            //keybd_event((byte)Keys.H, 0x00, KEYEVENTF_KEYDOWN, 0);
            //keybd_event((byte)Keys.H, 0x00, KEYEVENTF_KEYUP, 0);

        }


    }

    #region 로딩 완료 확장 메서드
    // 페이지 로딩 완료까지 대기하는 확장 메서드
    public static class SHDovVwEx
    {
        public static void Wait(this SHDocVw.InternetExplorer ie, int millisecond = 0)
        {
            int count = 0;
            while (ie.Busy == true)
            //while (ie.Busy == true || ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            {
                System.Threading.Thread.Sleep(100);
                count++;
                if (count == 300) return;
            }

        }
    }
    #endregion
}

// 로그인 윈폼 코드
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySql.Data 참조를 사용하기 위한 using 구문
using System.Net.NetworkInformation; // 인터넷 연결 상태 체크를 위한 using 구문

namespace deal_Program // namespace deal_Program 생성
{
    public partial class formSignIn : Form // SIGN_IN 부분 클래스 Form으로부터 상속을 받음. public형으로 선언
    {
        // [ 첫 실행 ]
        // 폼 생성자
        public formSignIn() 
        {
            InitializeComponent(); // 컨트롤 배치
        }
        // 폼 로드시 실행
        private void formSignIn_Load(object sender, EventArgs e)
        {
            Checkinternet(); // Checkinternet(인터넷 확인) 메소드를 실행
            this.ActiveControl = txtboxId; // 컨트롤의 포커스를 아이디 텍스트 박스로 설정
            timerCheckInternet.Tick += timerCheckInternet_Tick; // 인터넷 연결 확인 타이머의 Tick 이벤트에 timerCheckInternet_Tick 메소드를 추가
            timerCheckInternet.Start(); // 타이머를 시작
        }

        // [ 버튼 및 기능 구현 ]
        // 회원가입 버튼을 눌렀을 경우 실행하는 메소드
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            formSignUp _sign_up = new formSignUp(false); // 회원가입 폼 객체를 생성
            _sign_up.ShowDialog(); // 회원가입 윈폼을 오픈.
        }
        // 로그인 버튼을 눌렀을 경우 실행하는 메소드
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtboxId.Text == string.Empty) // 만약 아이디 텍스트 박스가 비었다면
            {
                labelAlert.Text = "아이디를 입력하세요!"; // 알림 라벨의 텍스트를 해당 텍스트로 변경
                return; // 메소드 종료
            }
            if (txtboxPw.Text == string.Empty) // 만약 비밀번호 텍스트 박스가 비었다면
            {
                labelAlert.Text = "비밀번호를 입력하세요!"; // 알림 라벨의 텍스트를 해당 텍스트로 변경
                return; // 메소드 종료
            }

            string _tableName = (checkboxModerator.Checked) ? "moderator" : "user"; // 접근할 테이블 명을 관리자 모드 체크 박스의 체크 유무에 따라 접근 하는 테이블이 달라짐.
            Form Homeform = null; // Form Homeform을 선언하고 차후 관리자, 유저에 따라 Homeform에 객체가 부여됨.

            try
            {
                MYSQL.mysql.Open(); // MySql의 서버에 연결
                string _query = string.Format("SELECT * FROM {0} WHERE ID='{1}'", _tableName, txtboxId.Text); // 관리자 모드 체크 여부에 따라 관리자 테이블인지 유저 테이블인지를 결정, 아이디 텍스트 박스의 문자열을 이용하여 문자열 포맷으로 쿼리를 생성
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // _query문을 MYSQL.mysql에 연결된 DB에서 실질적으로 실행될 쿼리문 객체로 형성
                MySqlDataReader _rdr = _command.ExecuteReader(); // 데이터 리더 _rdr에 쿼리문 실행을 통해 데이터를 받음

                if (_rdr.Read()) // 만약 한 행이 읽어진다면
                {
                    if (_rdr["PASSWORD"].ToString() == txtboxPw.Text) // _rdr의 PASSWORD열의 값을 문자열화 시켰을때 비밀번호 텍스트 박스의 문자열과 같다면
                    {
                        labelAlert.Text = string.Empty; // 올바르게 로그인이 되었기 때문에 결과 라벨을 공백으로 설정
                        if(checkboxModerator.Checked) // 만약 '관리자 로그인' 이 체크되어있을 경우
                        {
                            Moderator userData = new Moderator(_rdr); // 관리자 객체를 생성하고
                            Homeform = new formMDhome(userData); // Moderator.Home 폼 객체를 생성하여 userData 객체를 보냄으로써 데이터 전송
                        }
                        else // 체크가 안되어있을 경우
                        {
                            User userData = new User(_rdr); // 유저 객체를 생성하고
                            Homeform = new formUShome(userData,false); // User.Home 폼 객체를 생성하여 userData 객체를 보냄으로써 데이터를 전송하고 false를 보내서 유저 폼에서 유저 모드로 열리게 설정
                        }
                        _rdr.Close(); // _rdr의 연결을 해제
                        MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결 해제
                        timerCheckInternet.Stop(); // 인터넷 확인 타이머를 멈춤
                        this.Hide(); // 해당 폼을 숨기고
                        Homeform.Show(); // Homeform에 생성한 폼을 보여줌
                        return; // 메소드 종료
                    }
                    // 만약 DB에 있는 비밀번호와 텍스트 박스 비밀번호가 다르다면
                    txtboxPw.Text = string.Empty; // 비밀번호 텍스트 박스의 텍스트를 공백으로 처리하고
                    labelAlert.Text = "비밀번호가 잘못 되었습니다!"; // 결과 라벨의 텍스트를 문자열로 설정
                    txtboxPw.Focus(); // 비밀번호 텍스트 박스에 포커스를 줌
                    _rdr.Close(); // _rdr과의 연결을 해제
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결되어 있는 DB와의 연결을 해제
                    return; // 메소드 종료
                }
                // 행이 안읽어지면 아이디가 없기 때문에
                txtboxId.Text = string.Empty; // 아이디 텍스트 박스를 공백으로 처리
                txtboxPw.Text = string.Empty; // 비밀번호 텍스트 박스를 공백으로 처리
                labelAlert.Text = "존재하지 않는 아이디입니다."; // 결과 라벨의 텍스트를 문자열로 설정
                txtboxId.Focus(); // 아이디 텍스트 박스에 포커스를 줌
                _rdr.Close(); // _rdr과의 연결을 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message,"오류",MessageBoxButtons.OK,MessageBoxIcon.Warning); // 메세지 박스를 출력, 예외처리 메세지, 창 이름, OK 버튼, Warning 아이콘을 출력
            }
            finally // try, catch 이후 구문 실행
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결되어 있는 DB와의 연결을 해제
            }
        }
        // 관리자 모드의 체크박스가 바뀔때마다 실행하는 메소드
        private void checkboxModerator_CheckedChanged(object sender, EventArgs e)
        {
            statusMode.Text = checkboxModerator.Checked ? "관리자 모드" : "유저 모드"; // '관리자 모드'를 체크 할 시에 상태창 모드 텍스트를 관리자 모드로 바꾸고 체크 해제시 유저모드로 바꿈
        }
        // 아이디 비밀번호 찾는 라벨을 클릭했을 경우 실행되는 이벤트
        private void labelFindIdPw_Click(object sender, EventArgs e)
        {
            formFindIP _FIND_ID_PW = new formFindIP(); // FIND_IP_PW 폼의 객체를 생성하고
            _FIND_ID_PW.ShowDialog(); // 폼을 독립적으로 연다
        }

        // [ 실시간 갱신 ]
        // Checkinternet (인터넷 확인) 메소드
        private void Checkinternet()
        {
            bool connected = NetworkInterface.GetIsNetworkAvailable(); // bool 형 connected 변수를 선언하고, NetworkInterface.GetIsNetworkAvailable 메소드를 실행해서 현재 컴퓨터가 네트워크에 연결되어있는지를 확인, 연결되어있다면 true, 아니면 false를 반환
            if (connected) // 연결되어 있다면
            {
                toolStripStatusInternet.Text = "인터넷 : 연결됨"; // 상태 표시줄의 인터넷 확인 텍스트를 문자열로 대입
            }
            else // 연결이 되어있지 않으면
            {
                MessageBox.Show("인터넷 연결 안됨", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용, 창 이름, OK버튼, Error 아이콘을 출력
                toolStripStatusInternet.Text = "인터넷 : 연결안됨"; // 상태 표시줄의 인터넷 확인 텍스트를 문자열로 대입
            }
        }
        // 5초마다 인터넷을 체크하는 메소드
        private void timerCheckInternet_Tick(object sender, EventArgs e)
        {
            Checkinternet(); // Checkinternet 메소드 실행
        }

        // [ 폼 종료 ]
        // 로그인 폼을 닫을때 실행되는 이벤트
        private void formSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerCheckInternet.Stop(); // 타이머를 종료
            Application.Exit(); // 프로그램 자체를 꺼버림.
        }
        // 종료 버튼을 눌렀을 경우 실행하는 메소드
        private void btnExit_Click(object sender, EventArgs e)
        {
            formExitCheck _exit_check = new formExitCheck(); // 종료 폼 객체를 생성하고
            _exit_check.ShowDialog(); // 종료 윈폼을 단독적으로 오픈
        }
    }
}

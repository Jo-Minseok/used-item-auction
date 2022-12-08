using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formMDhome : Form
    {
        Moderator _moderator = new Moderator(); // 관리자 객체 _moderator 생성
        Dictionary<string, string> keyValues = new Dictionary<string, string>() // 딕셔너리 <키, 값> 형식으로 둘다 string으로 선언해주고 객체를 선언
        {
            {"ID","ID" },{"이메일","EMAIL"},{"닉네임","NICKNAME" } // 해당 키와 값들로 초기화
        };
        // [ 첫 실행 ]
        // 폼 생성자
        public formMDhome(Moderator md)
        {
            InitializeComponent(); // 컨트롤을 배치
            _moderator = md; // 로그인으로부터 받은 관리자 객체 md를 _moderator에 참조 대입
        }
        // 폼 로드시 실행되는 메소드
        private void formMDhome_Load(object sender, EventArgs e)
        {
            cbboxSearch.SelectedIndex = 0; // 콤보 박스의 선택 값을 제일 첫 값으로 설정
            this.ActiveControl = txtboxSearch; // 집중되는 컨트롤을 검색 부분의 텍스트 박스로 설정
        }
        // [ 버튼 및 기능 구현 ]
        // '경매 물건 관리' 버튼 구현부
        private void btnObjManage_Click(object sender, EventArgs e)
        {
            Form _frm = new formUShome(_moderator,_moderator.moderator);
            _frm.Show();
        }
        // '검색' 버튼 구현부
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (cbboxSearch.SelectedIndex != -1) // 콤보박스가 선택이 되었다면
            {
                if (txtboxSearch.Text != string.Empty) // 만약 검색하는 텍스트 박스의 내용이 비었지 않았다면
                {
                    try // 트라이 문
                    {
                        MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                        string _query = string.Format("SELECT * FROM user WHERE {0} = '{1}'", keyValues[cbboxSearch.SelectedItem.ToString()], txtboxSearch.Text); // 쿼리문 작성, 콤보박스에서 선택한 값의 문자열을 키로 넣었을때 나오는 값을 검색 조건으로 하고, 텍스트 박스 안의 값을 검색 값으로 문자열 포맷에 맞게 작성
                        MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문 객체화를 시킴
                        MySqlDataReader _rdr = _command.ExecuteReader(); // 데이터 리더 _rdr을 선언하고 _command를 실행했을때 나오는 데이터를 받아옴
                        if (_rdr.Read()) // 쿼리 조건에 맞는 유저가 존재할 경우
                        {
                            txtboxNick.Text = _rdr["NICKNAME"].ToString(); // 닉네임 텍스트 박스의 텍스트에 _rdr의 NICKNAME 열의 값을 문자열화 시키고 대입
                            txtboxName.Text = _rdr["NAME"].ToString(); // 이름 텍스트 박스의 텍스트에 _rdr의 NAME 열의 값을 문자열화 시키고 대입
                            txtBoxEmail.Text = _rdr["EMAIL"].ToString(); // 이메일 텍스트 박스의 텍스트에 _rdr의 EMAIL 열의 값을 문자열화 시키고 대입
                            txtboxPh.Text = _rdr["PHONE_NUMBER"].ToString(); // 전화번호 텍스트 박스의 텍스트에 _rdr의 PHONE_NUMBER 열의 값을 문자열화 시키고 대입
                            txtboxId.Text = _rdr["ID"].ToString(); // 아이디 텍스트 박스의 텍스트에 _rdr의 ID 열의 값을 문자열화 시키고 대입
                            txtboxPw.Text = _rdr["PASSWORD"].ToString(); // 비밀번호 텍스트 박스의 텍스트에 _rdr의 PASSWORD 열의 값을 문자열화 시키고 대입
                            txtboxBR.Text = _rdr["BR_DAY"].ToString(); // 생일 텍스트 박스의 텍스트에 _rdr의 BR_DAY 열의 값을 문자열화 시키고 대입
                            cbboxGender.SelectedItem = _rdr["GENDER"].ToString(); // 성별 콤보 박스가 선택한 값을 _rdr의 GENDER 열의 값을 문자열화 시키고 대입
                            txtboxAddress.Text = _rdr["ADDRESS"].ToString(); // 주소 텍스트 박스의 텍스트에 _rdr의 ADDRESS 열의 값을 문자열화 시키고 대입
                            txtboxCash.Text = _rdr["MONEY"].ToString(); // 계좌 텍스트 박스의 텍스트에 _rdr의 MONEY 열의 값을 문자열화 시키고 대입
                            byte[] bimage = null; // 프로필 이미지 바이트 배열을 null로 초기화
                            if (_rdr["PROFILE"].ToString()!=string.Empty) // _rdr의 PROFILE 열의 값의 문자열화 시켰을때 비었지 않았을 경우
                            {
                                bimage = (byte[])(_rdr["PROFILE"]); // bimage 이미지 바이트 배열에 _rdr의 PROFILE 열의 값을 바이트 배열화 시킨후 대입
                                MemoryStream mstream = new MemoryStream(bimage); // 메모리 스트림에 bimage의 바이트 배열을 연결
                                pictureboxProfile.Image = System.Drawing.Image.FromStream(mstream); // 픽처박스 프로필 이미지에 메모리 스트림으로부터 이미지화 시킨후 대입
                                mstream.Close(); // 메모리 스트림 연결 해제
                                _rdr.Close(); // _rdr연결 해제
                                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
                                return; // 함수 종료
                            }
                            // _rdr의 PROFILE 열의 값이 비었을 경우
                            pictureboxProfile.Image = Properties.Resources.unknown; // 픽처 박스 이미지에 프로퍼티.리소스에서 이미지인 unknown을 대입함
                            _rdr.Close(); // _rdr의 연결 해제
                            MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
                            return; // 함수 종료
                        }
                        else // 쿼리 조건에 맞는 유저가 존재하지 않을 경우
                        {
                            MessageBox.Show("해당 정보에 일치하는 사용자가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 내용, 창 이름, OK 버튼, 아이콘은 ERROR로 출력
                            _rdr.Close(); // _rdr의 연결을 해제
                        }
                    }
                    catch (Exception ex) // 예외 처리시
                    {
                        MessageBox.Show(ex.Message, "관리자 홈 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 예외 메세지, 창 이름, OK 버튼, Error 아이콘을 출력
                    }
                    finally // try, catch를 끝냈을 경우
                    {
                        MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결 해제
                    }
                    return; // 함수 종료
                }
                // 검색 텍스트 박스가 비었다면
                MessageBox.Show("어떠한 정보도 입력되지 않았습니다.","오류",MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용, 창 이름, 버튼, 아이콘 순서로 출력
                this.txtboxSearch.Focus(); // 텍스트 박스로 포커스를 둠
                return; // 함수 종료
            }
            // 콤보박스를 선택하지 않았을 경우
            MessageBox.Show("조건 박스를 선택하지 않았습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용, 창 이름, 버튼, 아이콘 순서로 출력
        }
        // 프로필 정보 '수정' 버튼 구현부
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (_moderator.moderator) // 만약 관리자 권한일 경우
            {
                if (!cbboxGender.Items.Contains(cbboxGender.Text)) // 만약 성별 콤보 박스의 텍스트가 아이템에 포함되어 있지 않을 경우
                {
                    if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { // 메세지 박스를 출력, 내용, 창 이름, OK 버튼, Error 아이콘을 출력하고 OK버튼을 누를 시
                        cbboxGender.SelectedIndex = 0; // 성별 콤보 박스의 0번째 인덱스를 선택
                        return; // 함수 종료
                    }
                }
                if (txtboxNick.Text != string.Empty && txtboxName.Text != string.Empty && txtBoxEmail.Text != string.Empty && txtboxPh.Text != string.Empty && txtboxId.Text != string.Empty && txtboxPw.Text != string.Empty && txtboxBR.Text != string.Empty && cbboxGender.SelectedItem.ToString() != string.Empty && txtboxAddress.Text != string.Empty) // 만약 모든 텍스트 박스가 비었지 않았다면
                {
                    if (openFileDialog1.FileName != string.Empty) // 오픈 다이얼로그를 통해서 파일을 였었다면
                    {
                        string check = _moderator.RefixUser(txtboxNick.Text, txtboxName.Text, txtBoxEmail.Text, txtboxPh.Text, txtboxId.Text, txtboxPw.Text, txtboxBR.Text, cbboxGender.SelectedItem.ToString(), txtboxAddress.Text, openFileDialog1.FileName, ulong.Parse(txtboxCash.Text, NumberStyles.AllowThousands)); // Moderator 클래스에 있는 객체 메소드를 이용하여 정보를 갱신, check에는 string.Empty 또는 예외 메세지가 들어오게 됨
                        if (check ==string.Empty) // 만약 check에서 비었다면 예외가 발생하지 않았기 때문에
                        {
                            MessageBox.Show("회원정보 수정 완료!", "수정 완료",MessageBoxButtons.OK,MessageBoxIcon.Information); // 회원정보 수정 완료를 알리는 메세지 박스를 출력, 내용, 창 이름, 메세지 박스 버튼 OK, 메세지 박스 아이콘 information 을 출력
                            return; // 함수 종료
                        }
                        else // check가 안비었다면 오류가 발생해서 예외처리가 발생했기 때문에
                        {
                            MessageBox.Show(check,"오류",MessageBoxButtons.OK,MessageBoxIcon.Error); // 메세지 박스 출력, 예외처리된 메세지를 출력, 창 이름, 메세지 박스 버튼 OK, 메세지 박스 아이콘 Error를 출력
                            return; // 함수 종료
                        }
                    }
                    else // 파일을 열지 않았다면
                    {
                        string check = _moderator.RefixUser(txtboxNick.Text, txtboxName.Text, txtBoxEmail.Text, txtboxPh.Text, txtboxId.Text, txtboxPw.Text, txtboxBR.Text, cbboxGender.SelectedItem.ToString(), txtboxAddress.Text, ulong.Parse(txtboxCash.Text, NumberStyles.AllowThousands)); // 위와 같이 Moderator 클래스에 있는 객체 메소드를 이용하여 정보를 갱신, 프로필 이미지는 바뀌지 않게 됨
                        if (check == string.Empty) // 만약 check에서 비었다면 예외가 발생하지 않았기 때문에
                        {
                            MessageBox.Show("회원정보 수정 완료!", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information); // 회원정보 수정 완료를 알리는 메세지 박스를 출력, 내용, 창 이름, 메세지 박스 버튼 OK, 메세지 박스 아이콘 information 을 출력
                            return; // 함수 종료
                        }
                        else // check가 안비었다면 오류가 발생해서 예외처리가 발생했기 때문에
                        {
                            MessageBox.Show(check, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 예외처리된 메세지를 출력, 창 이름, 메세지 박스 버튼 OK, 메세지 박스 아이콘 Error를 출력
                            return; // 함수 종료
                        }
                    }
                }
                // 하나라도 텍스트 박스가 비었다면
                MessageBox.Show("빈칸을 빠짐없이 입력하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 내용, 창 이름, OK 버튼, Error 아이콘 출력
            }
            else // 관리자 권한이 없을 경우
            {
                MessageBox.Show("관리자 권한이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 내용, 창 이름, OK 버튼, Error 아이콘 출력
            }
        }

        // '관리자 계정 추가' 버튼 구현부
        private void btnMDPlus_Click(object sender, EventArgs e)
        {
            Form _frm = new formSignUp(true); // 회원가입 폼에 true를 보냄으로써 회원가입 폼 기능을 관리자 회원가입 폼 기능으로 설정
            _frm.ShowDialog(); // 단독으로 폼을 열도록 설정
        }

        // 프로필 사진 '수정' 버튼 구현부
        private void btnRefix_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 만약 오픈 다이얼로그에서 파일을 선택을 했다면
            {
                pictureboxProfile.ImageLocation = openFileDialog1.FileName; // 픽처 박스 이미지의 위치를 파일을 선택한 위치를 함으로써 이미지를 선택한 이미지로 바꿔줌
            }
        }
        // 'DB 확인' 버튼 구현부
        private void btnDBCheck_Click(object sender, EventArgs e)
        {
            Form _frm = new formDBCheck(); // _frm에 DB를 확인하는 폼을 생성
            _frm.ShowDialog(); // _frm을 단독 오픈
        }
        // '계좌 잔고' 텍스트 박스 숫자키만 입력받는 키 프레스 메소드
        private void txtboxCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 만약 숫자 키나 백스페이스 키가 아니라면 이벤트를 처리했다고 인정하여 키 입력을 처리하지 않음
            {
                e.Handled = true;
            }
        }
        // '계좌 잔고' 텍스트 박스의 값에 3자리마다 ','를 넣어주는 메소드
        private void txtboxCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ulong text = ulong.Parse(txtboxCash.Text, NumberStyles.AllowThousands); // text를 ulong형식으로 선언해주고 텍스트 박스의 원본 숫자를 받고
                txtboxCash.Text = string.Format("{0:#,##0}", text); // 문자열 포맷 형식에 맞춰서 출력을 해줌
                txtboxCash.SelectionStart = txtboxCash.Text.Length; // 텍스트 박스의 입력 시작 부분을 텍스트 박스 텍스트의 마지막 위치로 설정
            }
            catch (Exception) // 예외 발생시(아예 숫자를 지웠다면)
            {
                txtboxCash.Text = "0"; // 계좌 텍스트 박스에 "0"을 대입
            }
        }
        // [ 폼 종료 ]
        // '종료' 버튼 구현부
        private void btnExit_Click(object sender, EventArgs e)
        {
            Form _frm = new formExitCheck(); // 종료 폼을 생성
            _frm.ShowDialog(); // 종료 폼을 단독으로 오픈
        }
        // 폼이 닫힐때 실행되는 메소드
        private void formMDhome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // 애플리케이션을 종료
        }
    }
}

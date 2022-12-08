using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace deal_Program
{
    public partial class formUserModifyProfile : Form
    {
        User _user;
        // [ 첫 실행 ]
        // 폼 생성자 (User 객체를 받아옴)
        public formUserModifyProfile(User us) 
        {
            InitializeComponent(); // 폼 생성자 실행
            _user = us; // _user 멤버 객체에 us를 대입하여 연동되도록 설정
        }
        // 폼이 로드 되었을때 실행되는 메소드
        private void formUserModifyProfile_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtboxNick; // 닉네임 텍스트 박스를 집중 시킴
            txtboxNick.Text = _user.Nickname; // 닉네임 텍스트 박스안에 유저 닉네임을 프로퍼티로 받아와서 대입
            txtboxName.Text = _user.Name; // 이름 텍스트 박스 안에 유저 이름을 프로퍼티로 받아와서 대입
            txtboxEmail.Text = _user.Email; // 이메일 텍스트 박스 안에 유저 이메일을 프로퍼티로 받아와서 대입
            txtboxPh.Text = _user.PhNum; // 전화번호 텍스트 박스 안에 유저 전화번호를 프로퍼티로 받아와서 대입
            txtboxId.Text = _user.Id; // 아이디 텍스트 박스 안에 유저 아이디를 프로퍼티로 받아와서 대입
            txtboxPW.Text = _user.Password; // 비밀번호 텍스트 박스 안에 유저 비밀번호를 프로퍼티로 받아와서 대입
            txtboxBR.Text = _user.Birthday; // 생일 텍스트 박스 안에 유저 생일을 프로퍼티로 받아와서 대입
            cbboxGender.Text = _user.Gender; // 성별 콤보 박스 안에 유저 성별을 프로퍼티로 받아와서 대입
            txtboxAddress.Text = _user.Address; // 주소 텍스트 박스 안에 유저 주소를 프로퍼티로 받아와서 대입
            if(_user.Profile == null) // 유저 프로필이 없을 경우
            {
                pictureBoxProfile.Image = Properties.Resources.unknown; // 프로필 이미지를 프로퍼티 리소스 파일 안에서 unknown 이미지로 설정
                return; // return으로 해당 함수 종료
            }
            MemoryStream mstream = new MemoryStream(_user.Profile); // 메모리 스트림 mstream을 선언하고, _user.Profile에 바이트 배열로 이루어져있는 값을 받아와서 메모리 스트림에 연결
            pictureBoxProfile.Image = System.Drawing.Image.FromStream(mstream); // 메모리 스트림을 System.Drawing.Image.FromStream()에 대입하여 스트림을 이미지로 바꾼 후, 프로필 이미지에 대입
            mstream.Close(); // 메모리 스트림인 mstream 닫기
        }
        
        // [ 버튼 및 기능 구현 ]
        // btnModify_Click에서 반복을 통해, 사용될 구조체
        struct commandValues // 구조체 commandValues 선언
        {
            public string commandValue1; // 값 1
            public string commandValue2; // 값 2
            public string commandValue3; // 값 3을 선언
        }
        // 유저 정보 수정 버튼
        private void btnModify_Click(object sender, EventArgs e)
        {
            string _query; // MySql에 명령어를 보내기 위한 쿼리 문자열
            MySqlCommand _command; // MySqlcommand 에서 존재하는 함수들 ExecuteReader와 ExecuteNonQuery, ExecuteScalar에 사용하기 위해 MySqlcommand의 객체를 만들고
            MySqlDataReader _rdr; // MySql에서 데이터를 받아와야하기 때문에 데이터를 받아올 객체 _rdr을 생성
            bool ischeck = false; // bool 형 ischeck에 false를 대입 (콤보박스 Gender안에 직접 입력한 값이 있는지를 확인하는 변수
            commandValues[] commandValuefor = new commandValues[2]; // 구조체 commandValuefor를 배열로 2개 선언
            commandValuefor[0].commandValue1 = "EMAIL"; commandValuefor[0].commandValue2 = txtboxEmail.Text; commandValuefor[0].commandValue3 = "이메일"; // 구조체 배열의 0번째의 값들을 해당 값들로 초기화
            commandValuefor[1].commandValue1 = "NICKNAME"; commandValuefor[1].commandValue2 = txtboxNick.Text; commandValuefor[1].commandValue3 = "닉네임"; // 구조체 배열의 1번째의 값들을 해당 값들로 초기화
            for (int i = 0; i < cbboxGender.Items.Count; i++) // 콤보 박스 안에 있는 아이템의 개수만큼 반복
            {
                if (cbboxGender.Text == cbboxGender.Items[i].ToString()) // 만약 성별 박스 안에 있는 텍스트가 콤보 박스 안에 있는 아이템(문자열로 변환)일 경우
                {
                    ischeck = true; // ischeck에 true를 대입
                    break; // break;를 통해서 for문 탈출
                }
            }
            if (ischeck == false) // ischeck가 false일 경우
            {
                if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { // 메세지 박스를 출력, 문자열, 창 이름, 버튼, 아이콘 순으로 출력하고 메세지 박스의 결과가 OK버튼일 경우
                    cbboxGender.SelectedIndex = 0; // 0번째 성별(남)을 선택
                } 
            }
            try // 트라이 구문(MySql 이용)
            {
                MYSQL.mysql.Open(); // MySql의 DB에 연결
                if (txtboxNick.Text != string.Empty && txtboxName.Text != string.Empty && txtboxEmail.Text != string.Empty && txtboxPh.Text != string.Empty && txtboxId.Text != string.Empty && txtboxPW.Text != string.Empty && txtboxBR.Text != string.Empty && cbboxGender.Text != string.Empty && txtboxAddress.Text != string.Empty) // 만약 모든 텍스트 안이 비었지 않았다면
                {
                    if (openFileDialog1.FileName != string.Empty) // 파일 선택한게 있다면
                    {
                        byte[] imageBt = null; // 이미지 바이트 배열을 선언하고 null로 초기화
                        FileStream fstream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read); // 파일 다이얼로그의 파일 위치를 파일 스트림안에 넣고, 열기 모드로, 파일 접근 권한은 읽기 모드로 하여 생성
                        BinaryReader br = new BinaryReader(fstream); // 바이너리 읽기인 br을 선언하고, 파일 스트림 fstream으로부터 이진 파일로 받아서 br에 저장
                        imageBt = br.ReadBytes((int)fstream.Length); // br에 저장된 파일을 파일 스트림의 길이만큼 바이트로 읽어서 imageBt 바이트 배열에 저장
                        br.Close(); // 바이너리 읽기인 br을 종료
                        fstream.Close(); // 파일 스트림 fstream 종료
                        if (txtboxPW.Text == _user.Password) // 만약 비밀번호 텍스트 박스가 유저의 비밀번호와 같다면 비밀번호를 바꿀 필요가 없기 때문에
                        {
                            for (int i = 0; i < 2; i++) // 2번 반복
                            {
                                _query = string.Format("SELECT * FROM user WHERE {0} = '{1}'", commandValuefor[i].commandValue1, commandValuefor[i].commandValue2); // 처음에 이메일을 검사, 두번째로 닉네임을 검사하는 쿼리문을 작성
                                _command = new MySqlCommand(_query, MYSQL.mysql); // 명령어를 sql.mysql에 대입
                                _rdr = _command.ExecuteReader(); // rdrID에 SQL로부터 행을 받아옴. ExecuteReader는 데이터를 받아오는 쿼리문으로써 데이터는 MySqlDataReader 라는 클래스의 객체로 리턴되기 때문에, MySqlDataReader인 _rdr에 대입
                                if (_rdr.HasRows) // rdr에 행이 있을 경우
                                {
                                    _rdr.Read(); // rdr로 통해서 1행을 받아옴
                                    if (_rdr["ID"].ToString() != _user.Id) // _rdr의 ID열에 위치한 값을 문자열로 바꾸고 그게 본인이 아닐 경우
                                    {
                                        _rdr.Close(); // rdr를 끊어줌.
                                        MYSQL.mysql.Close(); // MySql의 DB와 연결을 끊음
                                        MessageBox.Show(string.Format("{0} 중복!", commandValuefor[i].commandValue3), "오류"); // 메시지 박스 출력
                                        return; // 함수 종료
                                    }
                                }
                                _rdr.Close(); // DataReader의 객체 rdrID를 통해 sql과 데이터 교류를 끊어줌.
                            }
                            _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', GENDER = '{5}', ADDRESS = '{6}', PROFILE = @IMG WHERE ID = '{7}'", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, _user.Id); // 쿼리를 작성, 업데이트 하는 구문으로써, 닉네임 텍스트 박스, 이름 텍스트 박스, 이메일 텍스트 박스, 전화번호 텍스트 박스, 생일 텍스트 박스, 성별 콤보 박스의 텍스트, 주소 텍스트 박스를 문자열 포맷에 맞게 대입하고 업데이트 위치는 유저의 아이디로 설정
                            _command = new MySqlCommand(_query, MYSQL.mysql); // MySqlCommand 객체를 새로 생성, 쿼리를 MYSQL.mysql에 연결되어있는 DB에 연결하기 위해 만들어줌
                            _command.Parameters.Add(new MySqlParameter("@IMG", imageBt)); // 짜여진 쿼리에서 imageBt의 바이트 배열을 쿼리로 작성하기에는 너무 길기 때문에 @IMG를 파라미터 형식으로 지정
                            _command.ExecuteNonQuery(); // 만들어진 쿼리를 실행, 데이터를 불러오는게 아니기 때문에 ExecuteNonQuery로 데이터 삽입/삭제/업데이트시 이용하는 함수를 사용
                            _user.UpdateUserInformation(txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text,imageBt); // 유저 객체의 업데이트 유저 정보 함수에 해당 문자열, 바이트 배열을 대입하여 객체 정보를 갱신
                            MessageBox.Show("회원정보 수정 완료!", "수정 완료"); // 메세지 박스를 띄움, 내용, 창 이름 순서
                        }
                        else // 비밀번호 텍스트 박스가 유저의 비밀번호와 다르다면 비밀번호도 갱신해줘야하기 때문에 해당 구문을 실행
                        {
                            bool _special = false, _num = false, _alpha = false; // 특수문자, 숫자, 알파벳을 bool 타입으로 전부 false로 초기화

                            foreach (char x in txtboxPW.Text) // 문자 x를 문자열 txtboxPw.Text의 요소들을 대입하며 반복 실행
                            {
                                if (char.IsLower(x) || char.IsUpper(x)) // 만약 비밀번호에 알파벳이 대 소문자가 포함되어 있을 경우
                                {
                                    _alpha = true; // 알파벳 존재를 true로 설정
                                }
                                else if (char.IsNumber(x)) // 만약 비밀번호에 숫자가 포함되어 있을 경우
                                {
                                    _num = true; // 숫자 존재를 true로 설정
                                }
                                else
                                {
                                    // 만약 비밀번호에 특수문자가 포함되어 있을 경우
                                    foreach (char p in "-!@#$%^&*") // 문자 p를 문자열 "-!@#$%^&*" 요소들을 대입하며 반복 실행
                                    {
                                        if (x == p)  // PW_BOX.Text에 있는 문자가 위의 문자열 안에 있을 경우
                                        {
                                            _special = true; // 특수문자 존재를 true로 설정
                                            break; // foreach 문 탈출
                                        }
                                    }
                                }
                            }
                            if (_special && _num && _alpha) // 만약 특수문자, 숫자, 알파벳이 포함되어있을 경우
                            {
                                if (txtboxPW.Text != txtboxPWC.Text) // 만약 텍스트 박스의 비밀번호가 비밀번호 확인 텍스트 박스의 문자열과 다르다면
                                {
                                    MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                    if (MessageBox.Show("비밀번호 수정과 비밀번호 확인 칸의 비밀번호들이 다릅니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 메세지, 창 이름, 버튼, 아이콘 순으로 출력하고 버튼 OK를 누를 경우
                                    {
                                        this.ActiveControl = txtboxPW; // 비밀번호 텍스트 박스를 활성화
                                        return; // 함수 종료
                                    }
                                }
                                else if (txtboxPW.Text.Length < 8 || txtboxPW.Text.Length > 16) // 위의 조건에 부합하지 않고 해당 조건에 부합할 경우 (비밀번호 길이가 8~16자리가 아닐 경우)
                                {
                                    MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                    if (MessageBox.Show("비밀번호는 8~16자리를 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메시지 박스를 메세지, 창 이름, 버튼, 아이콘 순으로 출력하고 버튼 OK를 누를 경우
                                    {
                                        this.ActiveControl = txtboxPW; // 비밀번호 텍스트 박스를 활성화
                                        return; // 함수 종료
                                    }
                                }

                                else // 위의 모든 조건에 부합하지 않다면 비밀번호가 올바르게 입력되었다고 인식하고
                                {

                                    for (int i = 0; i < 2; i++) // 2번 반복
                                    {
                                        _query = string.Format("SELECT * FROM user WHERE {0} = '{1}'", commandValuefor[i].commandValue1, commandValuefor[i].commandValue2); // 이메일, 닉네임 순으로 검사하는 쿼리문
                                        _command = new MySqlCommand(_query, MYSQL.mysql); // 명령어를 MySqlCommand로 객체화 시키고
                                        _rdr = _command.ExecuteReader(); // rdrID에 SQL로부터 행을 받아옴.
                                        if (_rdr.HasRows) // rdr에 행이 있을 경우
                                        {
                                            _rdr.Read(); // rdr에 Read를 해서 한 행을 받아옴
                                            if (_rdr["ID"].ToString() != _user.Id) // 불러온 데이터 테이블에서 ID 열을 문자열화 시키고 문자열화 시킨 값이 본인 아이디가 아닐 경우
                                            {
                                                _rdr.Close(); // rdr를 끊어줌.
                                                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 끊어줌
                                                MessageBox.Show(string.Format("{0} 중복!", commandValuefor[i].commandValue3), "오류",MessageBoxButtons.OK,MessageBoxIcon.Error); // 메시지 박스 출력으로 어느 부분이 에러가 났는지 출력, 창 이름은 "오류"로 OK버튼, 아이콘은 Error(에러) 아이콘으로 메세지 박스 출력
                                                return; // 함수 종료
                                            }
                                        }
                                        _rdr.Close(); // DataReader의 객체 rdrID를 통해 sql과 데이터 교류를 끊어줌.
                                    }
                                    _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', GENDER = '{5}', ADDRESS = '{6}', PASSWORD = '{7}', PROFILE = @IMG WHERE ID = '{8}'", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, txtboxPW.Text, _user.Id); // 쿼리문을 작성 문자열 포맷에 맞게 값들로 대입해주고, 유저 아이디가 있는 곳으로 업데이트 시켜주는 쿼리 구문을 작성
                                    _command = new MySqlCommand(_query, MYSQL.mysql); //  MySqlCommand 객체를 새로 생성, 쿼리를 MYSQL.mysql에 연결되어있는 DB에 연결하기 위해 만들어줌
                                    _command.Parameters.Add(new MySqlParameter("@IMG", imageBt)); // 프로필이 있기 때문에, @IMG 파라미터에 imageBt의 이미지를 바이트 배열로 변환한 값을 대입
                                    _command.ExecuteNonQuery(); // _comamnd 객체에 만들어진 최종 쿼리를 실행
                                    _user.UpdateUserInformation(txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, txtboxPW.Text, imageBt); // 유저 객체에 정보를 갱신
                                    MYSQL.mysql.Close(); // MYSQL로부터 연결을 해제
                                    MessageBox.Show("회원정보 수정 완료!", "수정 완료",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); // 메세지 박스 출력, 출력 내용, 창 이름, OK 버튼 생성, 아이콘은 에스터리스크(알림) 아이콘으로 설정
                                    return; // 함수 종료
                                }
                            }
                            else // 만약 특수문자, 숫자 알파벳이 하나라도 포함이 안되어 있다면
                            {
                                MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                if (MessageBox.Show("비밀번호는 8~16자리, 특수문자, 영어, 숫자를 포함해야합니다.","오류",MessageBoxButtons.OK,MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 내용, 창 이름, OK 버튼, 아이콘은 Error(에러)를 출력하고 OK 버튼을 누를 시
                                {
                                    this.ActiveControl = txtboxPW; // 포커스가 비밀번호 텍스트 박스로 가게 설정
                                    return; // 함수 종료
                                }
                            }
                        }
                    }
                    else // 파일 선택한게 없다면
                    {
                        if (txtboxPW.Text == _user.Password) // 비밀번호 텍스트 박스에 값이 유저 비밀번호와 같다면 비밀번호를 바꾸지 않아도 됨.
                        {
                            for (int i = 0; i < 2; i++) // 2번 반복
                            {
                                _query = string.Format("SELECT * FROM user WHERE {0} = '{1}'", commandValuefor[i].commandValue1, commandValuefor[i].commandValue2); // user 테이블로부터 구조체의 각 값들에 맞는 값이 있는지를 확인
                                _command = new MySqlCommand(_query, MYSQL.mysql); // 명령어를 MYSQL.mysql에 연결되어 있는 DB에 쿼리를 대입한 형식으로 객체를 생성
                                _rdr = _command.ExecuteReader(); // _rdr에 _command를 이용하여 데이터를 MySqlDataReader 형식으로 받아옴
                                if (_rdr.HasRows) // rdr에 행이 있을 경우
                                {
                                    _rdr.Read(); // _rdr의 한 행을 읽고
                                    if (_rdr["ID"].ToString() != _user.Id) // _rdr 테이블의 ID 열의 값을 문자열로 바꿔주고 유저 아이디와 다르다면
                                    {
                                        _rdr.Close(); // rdr를 끊어줌.
                                        MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제함
                                        MessageBox.Show(string.Format("{0} 중복!", commandValuefor[i].commandValue3), "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메시지 박스를 내용, 창이름, OK버튼, Error(에러) 아이콘을 출력
                                        return; // 함수 종료
                                    }
                                }
                                _rdr.Close(); // _rdr을 종료
                            }
                            _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', GENDER = '{5}', ADDRESS = '{6}' WHERE ID = '{7}'", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, _user.Id); // 문자열 포맷 형식에 맞게 쿼리를 작성, 목표 위치는 ID에 있는 값 (업데이트 해주는 쿼리문)
                            _command = new MySqlCommand(_query, MYSQL.mysql); // 명령어를 MYSQL.mysql에 연결되어 있는 DB에 쿼리를 대입한 형식으로 객체를 생성
                            _command.ExecuteNonQuery(); // 업데이트 쿼리문을 실행
                            _user.UpdateUserInformation(txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text); // 유저 정보를 업데이트
                            MYSQL.mysql.Close(); // MYSQL로부터 연결을 해제
                            MessageBox.Show("회원정보 수정 완료!", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // 메세지 박스 출력, 출력 내용, 창 이름, OK 버튼 생성, 아이콘은 에스터리스크(알림) 아이콘으로 설정
                            return; // 함수 종료
                        }
                        else // 비밀번호 텍스트 박스에 값이 유저 비밀번호와 일치하지 않다면 비밀번호를 바꿔야하기 떄문에
                        {
                            bool _special = false, _num = false, _alpha = false; // 특수문자, 숫자, 알파벳을 bool 타입으로 전부 false로 초기화

                            foreach (char x in txtboxPW.Text) // 문자 x를 문자열 txtboxPw.Text의 요소들을 대입하며 반복 실행
                            {
                                if (char.IsLower(x) || char.IsUpper(x)) // 만약 비밀번호에 알파벳이 대 소문자가 포함되어 있을 경우
                                {
                                    _alpha = true; // 알파벳 존재를 true로 설정
                                }
                                else if (char.IsNumber(x)) // 만약 비밀번호에 숫자가 포함되어 있을 경우
                                {
                                    _num = true; // 숫자 존재를 true로 설정
                                }
                                else
                                {
                                    // 만약 비밀번호에 특수문자가 포함되어 있을 경우
                                    foreach (char p in "-!@#$%^&*") // 문자 p를 문자열 "-!@#$%^&*" 요소들을 대입하며 반복 실행
                                    {
                                        if (x == p)  // PW_BOX.Text에 있는 문자가 위의 문자열 안에 있을 경우
                                        {
                                            _special = true; // 특수문자 존재를 true로 설정
                                            break; // foreach 문 탈출
                                        }
                                    }
                                }
                            }
                            if (_special && _num && _alpha) // 만약 특수문자, 숫자, 알파벳이 포함되어있을 경우
                            {
                                if (txtboxPW.Text != txtboxPWC.Text) // 만약 텍스트 박스의 비밀번호가 비밀번호 확인 텍스트 박스의 문자열과 다르다면
                                {
                                    MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                    if (MessageBox.Show("비밀번호 수정과 비밀번호 확인 칸의 비밀번호들이 다릅니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 메세지, 창 이름, 버튼, 아이콘 순으로 출력하고 버튼 OK를 누를 경우
                                    {
                                        this.ActiveControl = txtboxPW; // 비밀번호 텍스트 박스를 활성화
                                        return; // 함수 종료
                                    }
                                }
                                else if (txtboxPW.Text.Length < 8 || txtboxPW.Text.Length > 16) // 위의 조건에 부합하지 않고 해당 조건에 부합할 경우 (비밀번호 길이가 8~16자리가 아닐 경우)
                                {
                                    MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                    if (MessageBox.Show("비밀번호는 8~16자리를 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메시지 박스를 메세지, 창 이름, 버튼, 아이콘(에러) 순으로 출력하고 버튼 OK를 누를 경우
                                    {
                                        this.ActiveControl = txtboxPW; // 비밀번호 텍스트 박스를 활성화
                                        return; // 함수 종료
                                    }
                                }
                                else // 위의 모든 조건에 부합하지 않을 경우
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        _query = string.Format("SELECT * FROM user WHERE {0} = '{1}'", commandValuefor[i].commandValue1, commandValuefor[i].commandValue2); // 문자열 포맷 형식에 맞게 구조체에서 각각 값을 대입
                                        _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결되어있는 DB로 입력
                                        _rdr = _command.ExecuteReader(); // rdr에 MySql로부터 데이터를 받아옴
                                        if (_rdr.HasRows) // rdr에 행이 있을 경우
                                        {
                                            _rdr.Read(); // 한 행을 받아옴
                                            if (_rdr["ID"].ToString() != _user.Id) // _rdr의 데이터 테이블에서 ID열에 있는 값을 문자열로 변환 후 유저 아이디와 같지 않다면
                                            {
                                                _rdr.Close(); // rdr를 끊어줌.
                                                MYSQL.mysql.Close(); // MYSQL을 끊어줌
                                                MessageBox.Show(string.Format("{0} 중복!", commandValuefor[i].commandValue3), "오류",MessageBoxButtons.OK,MessageBoxIcon.Error); // 메시지 박스 출력 내용, 창 이름, 버튼, 아이콘 순으로 출력
                                                return; // 함수 종료
                                            }
                                        }
                                        _rdr.Close(); // DataReader의 객체 rdrID를 통해 sql과 데이터 교류를 끊어줌.
                                    }
                                    _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', GENDER = '{5}', ADDRESS = '{6}', PASSWORD = '{7}' WHERE ID = '{8}'", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, txtboxPW.Text, _user.Id); // 업데이트 하는 쿼리를 작성, 문자열 포맷 형식에 맞게 설정, ID가 유저 아이디인 곳을 대상으로 업데이트 하는 쿼리문
                                    _command = new MySqlCommand(_query, MYSQL.mysql); // _command에 MySqlCommand의 객체를 생성, MYSQL.mysql에 연결된 DB에 해당 쿼리를 대입
                                    _command.ExecuteNonQuery(); // 쿼리를 실행
                                    _user.UpdateUserInformation(txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxBR.Text, cbboxGender.Text, txtboxAddress.Text, txtboxPW.Text); // 객체에 유저 정보를 업데이트
                                    MessageBox.Show("회원정보 수정 완료!", "수정 완료",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); // 메시지 박스를 메세지, 창 이름, 버튼, 아이콘(정보) 순으로 출력
                                }
                            }
                            else // 비밀번호에 알파벳, 숫자, 특수기호가 포함되어 있지 않을 경우
                            {
                                MYSQL.mysql.Close(); // MYSQL.mysql 과 연결된 DB와의 연결 해제
                                if (MessageBox.Show("비밀번호는 8~16자리, 특수문자, 영어, 숫자를 포함해야합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 내용, 창 이름, OK 버튼, 아이콘은 Error(에러)를 출력하고 OK 버튼을 누를 시
                                {
                                    this.ActiveControl = txtboxPW; // 포커스가 비밀번호 텍스트 박스로 가게 설정
                                    return; // 함수 종료
                                }
                            }
                        }
                    }
                }
                else // 만약 텍스트 박스가 하나라도 비었다면
                {
                    MessageBox.Show("빈칸을 빠짐없이 입력하세요!(비밀번호 변경이 아니라면 비밀번호 변경 제외)", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 메세지 박스를 띄움, 출력 내용, 창 이름, 버튼, 아이콘(경고) 순으로 출력
                }
            }
            catch(Exception ex) // 위의 구문에서 예외처리가 발생 시
            {
                MessageBox.Show(ex.Message, "유저 정보 수정 오류", MessageBoxButtons.OK ,MessageBoxIcon.Error); // 예외 처리에서 나온 예외의 메세지만 출력, 창 이름, OK버튼, 에러 아이콘인 메세지 박스를 출력
            }
            finally // try문이 끝날 경우 or catch로 예외가 잡히고 나서 실행하는 구분
            {
                MYSQL.mysql.Close(); // MYSQL.mysql과 연결된 DB로부터 연결을 해제
            }
        }
        // 유저 사진 '업로드' 버튼 구현부
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 파일을 여는 다이얼로그의 결과가 OK버튼일 경우
            {
                pictureBoxProfile.ImageLocation = openFileDialog1.FileName; // 폼의 프로필 픽처 박스의 이미지 위치를 오픈 다이얼로그에서 연 파일 위치로 설정
            }
        }
        
        // [ 폼 종료 ]
        // '취소'버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼을 닫음
        }
    }
}

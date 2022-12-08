// 회원가입 윈폼 코드
using MySql.Data.MySqlClient; // MySql.Data 참조를 사용하기 위한 using 구문
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace deal_Program // namespace deal_Program 생성
{
    public partial class formSignUp : Form // SIGN_UP 부분 클래스 Form으로부터 상속을 받음. public형으로 선언
    {
        private bool[] available = new bool[] { false, false, false, false, false, false, false, false, false, false }; // 회원가입이 가능한지 확인하는 배열, 모든 배열이 true일 경우 회원가입 가능, 확인용 인덱서를 선언
        private string mode; // formSignUp의 멤버 필드인 문자열 mode를 선언
        public bool FilePath // 파일 위치를 얻을 bool형 자동구현 프로퍼티
        {
            get; // 프로퍼티-겟
            set; // 프로퍼티-셋
        }
        public bool this[int index] // 접근 범위: public, 반환형 bool인 인덱스 생성
        {
            get // get 접근 
            {
                return available[index]; // available 배열의 index 번째의 값을 반환
            }
            set // set 접근
            {
                available[index] = value; // available 배열의 index 번째에 값을 대입.
            }
        }

        // [ 첫 실행 ]
        // SIGN_UP의 폼 생성자
        public formSignUp(bool moderator) 
        {
            InitializeComponent(); // 컨트롤들을 배치
            mode = moderator ? "moderator" : "user"; // 만약 관리자 권한이 true일 경우 모드를 moderator로 설정, true가 아닐 경우 user로 설정
        }
        // 폼 로드시 실행
        private void formSignUp_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtboxNick; // 폼의 활성화 컨트롤을 닉네임 텍스트 박스로 설정
            dateTimePickerBR.MaxDate = DateTime.Now; // 생년월일의 데이터 피커의 최대 날짜를 오늘로 설정, 미래에 태어날순 없기 떄문에 최대 오늘로 설정
        }

        // [ 버튼 및 기능 구현 ]
        // 닉네임 텍스트 박스의 텍스트가 바뀔 경우
        private void txtboxNick_TextChanged(object sender, EventArgs e)
        {
            if (txtboxNick.Text == string.Empty) // 만약 닉네임의 텍스트 박스에 아무것도 없을 시에
            {
                this[0] = false; // 인덱스를 이용하여 available의 0번째에 false를 대입
                return; // 함수 종료
            }
            this[0] = true; // 인덱스를 이용하여 available의 0번째에 true를 대입
        }

        // 이름 텍스트 박스에 이름을 작성했는지 확인하는 이벤트
        private void txtboxName_TextChanged(object sender, EventArgs e)
        {
            if (txtboxName.Text == string.Empty) // 만약 NAME_BOX의 텍스트 박스에 아무것도 없을 시에
            {
                this[1] = false; // 인덱스를 이용하여 available의 1번째에 false를 대입
                return;
            }
            this[1] = true; // 인덱스를 이용하여 available의 1번째에 true를 대입
        }
        // 이메일 텍스트 박스에 이메일을 작성했는지 확인하는 이벤트
        private void txtboxEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtboxEmail.Text == string.Empty) // 만약 EMAIL_BOX의 텍스트 박스에 아무것도 없을 시에
            {
                this[2] = false; // 인덱스를 이용하여 available의 2번째에 false를 대입
            }
            // 현재 이메일이 생성되어 있는지 확인
            this[2] = true; // 인덱스를 이용하여 available의 2번째에 true를 대입
        }
        // 전화번호 텍스트 박스에 전화번호를 작성했는지 확인하는 이벤트
        private void txtboxPh_TextChanged(object sender, EventArgs e)
        {
            if (txtboxPh.Text == string.Empty) // 만약 PH_BOX의 텍스트 박스에 아무것도 없을 시에
            {
                this[3] = false; // 인덱스를 이용하여 available의 3번째에 false를 대입
                return;
            }
            this[3] = true; // 인덱스를 이용하여 available의 3번째에 true를 대입
        }
        // 아이디 텍스트박스에 아이디를 작성했는지 확인하는 이벤트
        private void txtboxId_TextChanged(object sender, EventArgs e)
        {
            if (txtboxId.Text == string.Empty) // 만약 ID_BOX의 텍스트 박스에 아무것도 없을 시에
            {
                this[4] = false; // 인덱스를 이용하여 available의 4번째에 false를 대입
                return;
            }
            this[4] = true; // 인덱스를 이용하여 available의 4번째에 true를 대입
        }
        // 비밀번호 텍스트박스에 올바르게 비밀번호를 작성했는지 확인하는 이벤트, 비밀번호 텍스트 박스의 문자열이 바뀔때마다 실행
        private void txtboxPw_TextChanged(object sender, EventArgs e)
        {
            bool _special = false, _num = false, _alpha = false; // 특수문자, 숫자, 알파벳을 bool 타입으로 전부 false로 초기화

            foreach (char x in txtboxPw.Text)
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
                    foreach (char p in "-!@#$%^&*") // 문자 p를 문자열만큼 반복
                    {
                        if (x == p)  // PW_BOX.Text에 있는 문자가 위의 문자열 안에 있을 경우
                        {
                            _special = true; // 특수문자 존재를 true로 설정
                            break; // foreach 문을 종료
                        }
                    }
                }
            }

            if (_special == true && _num == true && _alpha == true && txtboxPw.Text.Length >= 8 && txtboxPw.Text.Length <= 16) // 만약 특수문자, 숫자, 알파벳이 포함되어 있고, 비밀번호의 길이가 8이상 16이하일 경우
            {
                labelPwCheck.Visible = false; // 비밀번호 확인 레이블의 텍스트를 공백으로 처리
                this[5] = true; // 인덱스를 이용하여 available의 5번째에 true를 대입
            }
            else
            {
                this[5] = false; // 인덱스를 이용하여 available의 5번째에 false를 대입
                labelPwCheck.Visible = true; // 비밀번호 확인 레이블의 텍스트 프로퍼티를 문자열로 바꿈.
            }
            if (txtboxPw.Text != txtboxPwc.Text) // 비밀번호 텍스트 박스의 문자열과 비밀번호 확인 텍스트 박스의 문자열이 일치하지 않을 경우
            {
                this[6] = false; // 인덱스를 이용하여 available의 6번째에 false를 대입
                labelPwcCheck.Visible = true; // 비밀번호 확인 레이블의 Text 프로퍼티를 문자열로 설정
                return; // 메소드 종료
            }
            this[6] = true; // 인덱스를 이용하여 available의 6번째에 true를 대입
            labelPwcCheck.Text = string.Empty; // 비밀번호 확인 레이블의 Text 프로퍼티를 공백으로 설정
        }
        // 비밀번호 확인 텍스트 박스의 문자열이 비밀번호의 텍스트 박스의 문자열과 동일한지 확인하는 이벤트, 비밀번호 확인 텍스트 박스의 문자열이 바뀔때마다 실행
        private void txtboxPwc_TextChanged(object sender, EventArgs e)
        {
            if (txtboxPw.Text != txtboxPwc.Text) // 비밀번호 텍스트 박스의 문자열과 비밀번호 확인 텍스트 박스의 문자열이 일치하지 않을 경우
            {
                this[6] = false; // 인덱스를 이용하여 available의 6번째에 false를 대입
                labelPwcCheck.Visible = true; // 비밀번호 확인 레이블의 Text 프로퍼티를 문자열로 설정
                return; // 메소드 종료
            }
            // 비밀번호 확인과 비밀번호가 일치하다면
            this[6] = true; // 인덱스를 이용하여 available의 6번째에 true를 대입
            labelPwcCheck.Text = string.Empty; // 비밀번호 확인 레이블의 Text 프로퍼티를 공백으로 설정
        }
        // '생년월일' 데이터 타임 픽커의 값이 바뀔 경우
        private void dateTimePickerBR_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerBR.Value == DateTime.Now) // 만약 데이트 타임 픽커의 값이 오늘이라면
            {
                this[7] = false; // 인덱서를 이용하여 available의 7번째에 false를 대입
                return; // 메소드 종료
            }
            // 오늘이 아닐 경우
            this[7] = true; // 인덱서를 이용하여 available의 7번째에 true를 대입
            
        }

        // 성별 콤보박스의 값이 바뀐다면
        private void cbboxGender_SelectedValueChanged(object sender, EventArgs e)
        {
            this[8] = true; // 인덱서를 이용하여 available의 8번째에 true를 대입
        }

        // 주소 텍스트 박스의 값이 바뀐다면
        private void txtboxAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtboxAddress.Text == string.Empty) // 만약 주소 텍스트 박스의 값이 비었다면
            {
                this[9] = false; // 인덱서를 이용하여 해당 객체의 available의 9번째에 false를 대입
                return; // 메소드 종료
            }
            // 비었지 않았다면
            this[9] = true; // 인덱서를 이용하여 해당 객체의 available의 9번째에 true를 대입
        }

        // 구조체 정의(멀티 맵핑을 하기 위해 만든것)
        struct commandValues
        {
            public string commandValue1; // 멤버 변수인 문자열 commandValue1을 선언 - DB 열
            public string commandValue2; // 멤버 변수인 문자열 commandValue2를 선언 - 텍스트 박스의 텍스트 값
            public string commandValue3; // 멤버 변수인 문자열 commandValue3을 선언 - 한글 아이템
        }
        // 회원가입 버튼을 눌렀을때 실행되는 함수, 마지막 최종적으로 어느 칸이 비었는지, 회원가입이 가능한지 확인하는 이벤트
        private void btnRegister_Click(object sender, EventArgs e)
        {
            short _count = 0; // short형 count 변수 선언 및 0 초기화
            string _text = string.Empty; // text 문자열을 선언 및 공백 초기화
            for (int i = 0; i < 10; i++) // 10번 반복
            {
                if (this[i]) // 만약 인덱스(available)의 i번째 요소가 true일 경우
                {
                    _count++; // count를 증가
                }
                else // 아닐 경우
                {
                    switch (i) // switch case문으로 어디칸이 잘못되었는지 알려주는 구문
                    {
                        case 0: // 닉네임의 칸이 비었을 경우
                            _text += "닉네임을 입력하지 않았습니다! \n"; // 문자열을 더해줌
                            break;
                        case 1: // 이름의 칸이 비었을 경우
                            _text += "이름을 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 2: // 이메일의 칸이 비었을 경우
                            _text += "이메일을 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 3: // 전화번호의 칸이 비었을 경우
                            _text += "전화번호를 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 4: // 아이디의 칸이 비었을 경우
                            _text += "아이디를 제대로 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 5: // 비밀번호를 특수문자, 길이를 제대로 입력하지 않았을 경우
                            _text += "비밀번호를 제대로 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 6: // 비밀번호 확인을 제대로 적었지 않았을 경우 
                            _text += "비밀번호 확인을 제대로 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 7: // 생일을 제대로 선택하지 않았을 경우
                            _text += "생일을 제대로 선택하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 8: // 성별을 제대로 선택하지 않았을 경우
                            _text += "성별을 제대로 선택하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                        case 9: // 주소를 제대로 선택하지 않았을 경우
                            _text += "주소를 제대로 입력하지 않았습니다!\n"; // 문자열을 더해줌
                            break; // switch 문 탈출
                    }
                }
            }
            if (_count == 10) // 만약 count가 10이라면 회원가입이 가능한 상태이므로
            {
                try // MySql에서 예외처리가 발생하므로 해당 구문을 통해서 예외를 잡아줌.
                {
                    MYSQL.mysql.Open(); // mysql.Open()으로 데이터베이스에 연결
                    commandValues[] commandValuefor = new commandValues[3]; // commandValuefor 배열을 생성하고 최대 3개의 요소로 생성
                    commandValuefor[0].commandValue1 = "ID"; commandValuefor[0].commandValue2 = txtboxId.Text; commandValuefor[0].commandValue3 = "아이디"; // 0번째 구조체의 각 값들을 문자열 값들로 대입
                    commandValuefor[1].commandValue1 = "EMAIL"; commandValuefor[1].commandValue2 = txtboxEmail.Text; commandValuefor[1].commandValue3 = "이메일"; // 1번째 구조체의 각 값들을 문자열 값들로 대입
                    commandValuefor[2].commandValue1 = "NICKNAME"; commandValuefor[2].commandValue2 = txtboxNick.Text; commandValuefor[2].commandValue3 = "닉네임"; // 2번째 구조체의 각 값들을 문자열 값들로 대입
                    string _query; // 쿼리문 선언
                    MySqlCommand _command; // 실질적 실행 쿼리문 객체 선언
                    MySqlDataReader _rdr; // 쿼리를 실행해서 받아올 데이터를 담을 데이터 리더 선언
                    for (int i = 0; i < 3; i++) // 0~2까지 3번 반복
                    {
                        _query = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", mode, commandValuefor[i].commandValue1, commandValuefor[i].commandValue2); // 쿼리문을 작성, DB의 열에 따른 실질적 값을 선택하는 쿼리문을 작성
                        _command = new MySqlCommand(_query, MYSQL.mysql); // MYSQL.mysql에 연결된 DB에 실질적으로 쓸 수 있는 쿼리문 객체를 생성
                        _rdr = _command.ExecuteReader(); // rdr에 MYSQL.mysql로부터 데이터를 받아옴
                        if (_rdr.HasRows) // rdr에 행이 있을 경우 중복되었다는 의미이기에 중복되었다는 메세지 박스를 출력
                        {
                            MessageBox.Show(string.Format("{0} 중복!", commandValuefor[i].commandValue3), "오류"); // 메세지 박스를 출력, 어떤 요소가 중복되었는지를 알려줌
                            _rdr.Close(); // rdr를 끊어줌.
                            MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결을 끊어줌
                            return; // 종료
                        }
                        _rdr.Close(); // DataReader의 객체 rdrID를 통해 sql과 데이터 교류를 끊어줌.
                    }

                    byte[] imageBt = null; // 프로필 이미지를 담을 바이트 배열 imageBt를 선언 및 null로 초기화
                    if (FilePath) // 만약 FilePath가 존재한다면 true, 없을 경우 false이므로 true일 경우
                    {
                        FileStream fstream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read); // 파일 스트림을 오픈 파일 다이얼로그에서 파일 위치에 있는 파일을 열기 모드로 열고 읽기 모드로 읽기
                        BinaryReader br = new BinaryReader(fstream); // 바이너리 리더 br에 파일 스트림으로 읽어온 fstream에 있는 파일을 읽어옴
                        imageBt = br.ReadBytes((int)fstream.Length); // imageBt 이미지 바이트 배열에 fstream의 길이만큼 바이트를 읽어옴
                        br.Close(); // 바이너리 리더의 연결을 해제
                        fstream.Close(); // 파일 스트림의 연결을 해제
                        _query = string.Format("INSERT INTO {9} (NICKNAME,NAME,EMAIL,PHONE_NUMBER,ID,PASSWORD,BR_DAY,GENDER,ADDRESS,PROFILE) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}',@IMG)", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxId.Text, txtboxPw.Text, dateTimePickerBR.Value.ToString("yyyy-MM-dd"), cbboxGender.SelectedItem, txtboxAddress.Text,mode); // 쿼리문을 작성, 문자열 포맷에 맞게 대입을 해주는데, INSERT 구문으로 user 또는 moderator 테이블에 값을 추가해줌 @IMG는 추후 파라미터 정의를 통해서 더해줌
                        _command = new MySqlCommand(_query, MYSQL.mysql); // _query 문을 MYSQL.mysql에 연결된 DB의 실질적 쿼리문으로 만들기 위해서 객체화
                        _command.Parameters.Add(new MySqlParameter("@IMG", imageBt)); // 객체화된 _command의 @IMG 부분을 imageBt로 바이트 배열의 값을 대입
                        _command.ExecuteReader(); // 쿼리를 실행
                        MessageBox.Show(string.Format("회원가입 성공!\n환영합니다. {0}님", txtboxName.Text), "회원가입 성공"); // 회원가입을 성공했다는 문자열을 메시지 박스를 통하여 출력, 사용자의 이름 출력을 위해 string.Format 메소드 사용
                        this.Close(); // 해당 폼을 닫음
                    }
                    else // 만약 FilePath가 존재하지 않다면
                    {
                        _query = string.Format("INSERT INTO {9} (NICKNAME,NAME,EMAIL,PHONE_NUMBER,ID,PASSWORD,BR_DAY,GENDER,ADDRESS) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", txtboxNick.Text, txtboxName.Text, txtboxEmail.Text, txtboxPh.Text, txtboxId.Text, txtboxPw.Text, dateTimePickerBR.Value.ToString("yyyy-MM-dd"), cbboxGender.SelectedItem, txtboxAddress.Text,mode); // 쿼리문을 작성, 데이터 테이블에서 값을 추가하는 쿼리문을 작성, 문자열 포멧에 맞게 쿼리를 작성해줌, 날짜 데이터 포맷을 설정해주고 해당 경우는 프로필이 없는 경우기 때문에 @IMG 생략
                        _command = new MySqlCommand(_query, MYSQL.mysql); // _query 문을 MYSQL.mysql에 연결된 DB의 실질적 쿼리문으로 만들기 위해서 객체화
                        _command.ExecuteReader(); // 쿼리를 실행
                        MessageBox.Show(string.Format("회원가입 성공!\n환영합니다. {0}님", txtboxName.Text), "회원가입 성공"); // 회원가입을 성공했다는 문자열을 메시지 박스를 통하여 출력, 사용자의 이름 출력을 위해 string.Format 함수 사용
                        this.Close(); // 해당 폼을 닫음
                    }
                }
                catch (Exception ex) // 예외가 발생할 경우
                {
                    MessageBox.Show(ex.Message, "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외 메세지, 창 이름, OK 버튼, Error 아이콘을 가진 메세지 박스를 출력
                }
                finally // try와 catch가 끝날 경우
                {
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결되어 있는 DB와의 연결을 끊음
                }
            }
            else // 만약 count가 6이 아니라면 회원가입이 불가능한 상태이므로
            {
                MessageBox.Show(_text, "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메시지 박스를 출력하는데, 어떤 부분을 안적었고 잘못 적었는지 메시지 박스로 띄우고, 창 이름은 회원가입 오류, OK 확인 버튼, Error 아이콘을 출력
            }
        }
        // '업로드' 버튼 구현부
        private void btnProfileUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 만약에 파일을 열었을때 파일을 선택하고 OK버튼을 눌렀다면
            {
                pictureboxProfile.ImageLocation = openFileDialog1.FileName; // 프로필 픽처박스 이미지의 위치를 파일 위치로 설정하여 이미지를 불러옴
                FilePath = true; // FilePath 프로퍼티를 true로 설정
                return; // 메소드 종료
            }
            FilePath = false; // OK를 안눌렀을 경우 false로 설정
        }

        // '삭제' 버튼 구현부
        private void btnProfileRemove_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty; // 오픈 파일 다이얼로그의 파일 위치를 공백으로 설정
            pictureboxProfile.Image = Properties.Resources.unknown; // 프로필 픽처 박스에 프로퍼티.리소스의 unknown 이미지를 받아옴
            FilePath = false; // FilePath 프로퍼티를 false로 설정
        }

        // [ 폼 종료 ]
        // '취소' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e) 
        {
            this.Close(); // 해당 윈폼을 닫음
        }
    }
}

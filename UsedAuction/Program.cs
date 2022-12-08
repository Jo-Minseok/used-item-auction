using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO; // 파일 입출력을 위한 Input, Output
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySql에 접속하기 위한 클래스들, 메소드들을 사용

namespace deal_Program // 이름공간 deal_Program 생성
{
    public class User // 유저 클래스 생성
    {
        private ulong money; // private 접근자인 ulong형 money(돈) 멤버 필드 선언
        public byte[] Profile // 프로필 이미지를 바이트 배열로 받는 자동 프로퍼티
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Nickname // 문자열 Nickname 자동 프로퍼티(닉네임)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Name // 문자열 Name 자동 프로퍼티(이름)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Email // 문자열 Email 자동 프로퍼티(이메일)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string PhNum // 문자열 PhNum 자동 프로퍼티(전화번호)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Id // 문자열 Id 자동 프로퍼티(아이디)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Password // 문자열 Password 자동 프로퍼티(비밀번호)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Birthday // 문자열 Birthday 자동 프로퍼티(생일)
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Gender // 문자열 Gender(성별) 자동 프로퍼티
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public string Address // 문자열 Address(주소) 자동 프로퍼티
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public int CountInAuction // 정수형(입찰 횟수) 자동 프로퍼티
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public int CountSucAuction // 정수형(낙찰 횟수) 자동 프로퍼티
        {
            get; // 자동 프로퍼티-겟
            set; // 자동 프로퍼티-셋
        }
        public ulong Money // 부호없는 long형 Money (돈) 일반 프로퍼티
        {
            get
            {
                return money; // 멤버 필드를 반환
            } // 겟 정의
            set
            {
                money = value; // Money에 의해서 들어온 값을 money인 private형 멤버 필드에 대입
            }// 셋 정의
        }

        public User(MySqlDataReader rdr) // User 객체 생성자로 MySqlDataReader의 테이블 rdr을 받아옴
        {
            this.Nickname = rdr["NICKNAME"].ToString(); // rdr의 NICKNAME 열에 있는 값을 문자열화 하고 해당 객체의 프로퍼티에 대입
            this.Name = rdr["NAME"].ToString(); // rdr의 NAME 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Email = rdr["EMAIL"].ToString(); // rdr의 EMAIL 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.PhNum = rdr["PHONE_NUMBER"].ToString(); // rdr의 PHONE_NUMBER 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Id = rdr["ID"].ToString(); // rdr의 ID 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Password = rdr["PASSWORD"].ToString(); // rdr의 PASSWORD 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Birthday = rdr["BR_DAY"].ToString(); // rdr의 BR_DAY 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Gender = rdr["GENDER"].ToString(); // rdr의 GENDER 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.Address = rdr["ADDRESS"].ToString(); // rdr의 ADDRESS 열에 있는 값을 문자열화하고 해당 객체의 프로퍼티에 대입
            this.CountInAuction = Convert.ToInt32(rdr["COUNT_IN_AUCTION"]); // rdr의 COUNT_IN_AUCTION 열에 있는 값을 int형으로 변환하고 해당 객체의 프로퍼티에 대입
            this.CountSucAuction = Convert.ToInt32(rdr["COUNT_SUC_AUCTION"]); // rdr의 COUNT_SUC_AUCTION 열에 있는 값을 int형으로 변환하고 해당 객체의 프로퍼티에 대입
            this.Money = Convert.ToUInt64(rdr["MONEY"]); // rdr의 MONEY 열에 있는 값을 ulong 형으로 변환하고 해당 객체의 프로퍼티에 대입
        }
        public User() // User의 디폴트 객체 생성자
        {
            Nickname = string.Empty; // Nickname 프로퍼티에 공백 문자열로 대입
            Name = string.Empty; // Name 프로퍼티에 공백 문자열로 대입
            Email = string.Empty; // Email 프로퍼티에 공백 문자열로 대입
            PhNum= string.Empty; // PhNum 프로퍼티에 공백 문자열로 대입
            Id = string.Empty; // Id 프로퍼티에 공백 문자열로 대입
            Password = string.Empty; // Password 프로퍼티에 공백 문자열로 대입
            Birthday = string.Empty; // Birthday 프로퍼티에 공백 문자열로 대입
            Gender = string.Empty; // Gender 프로퍼티에 공백 문자열로 대입
            Address = string.Empty; // Address 프로퍼티에 공백 문자열로 대입
            CountInAuction = 0; // CountInAuction 프로퍼티에 0을 대입
            CountSucAuction = 0; // CountSucAuction 프로퍼티에 0을 대입
            Money = 0; // 돈 프로퍼티에 0을 대입
        }

        // 멤버 메소드 선언, 인자 값으로 DB로부터 올바른 값들을 받아오는 형식
        // 'User.ModifyProfile.cs'에서 사용되며, 프로필 이미지도 바꿀때 사용되는 메소드
        public void UpdateUserInformation(string nick, string name, string email, string phone_number, string birthday, string gender, string address, byte[] image) // 인자값 닉네임, 이름, 이메일, 전화번호, 생일, 성별, 주소, 프로필 이미지
        {
            this.Nickname = nick; // 객체의 Nickname 프로퍼티에 문자열 nick을 대입(DB로부터 받아온 닉네임)
            this.Name = name; // 객체의 Name 프로퍼티에 문자열 name을 대입(DB로부터 받아온 이름)
            this.Email = email; // 객체의 Email 프로퍼티에 문자열 email을 대입(DB로부터 받아온 이메일)
            this.PhNum = phone_number; // 객체의 PhNum 프로퍼티에 문자열 phone_number를 대입(DB로부터 받아온 전화번호)
            this.Birthday= birthday; // 객체의 birthday 프로퍼티에 문자열 birthday를 대입(DB로부터 받아온 생일)
            this.Gender = gender; // 객체의 gender 프로퍼티에 문자열 gender를 대입(DB로부터 받아온 성별)
            this.Address = address; // 객체의 Address 프로퍼티에 문자열 address를 대입(DB로부터 받아온 주소)
            this.Profile = image; // 객체의 Profile 프로퍼티에 바이트 배열 image를 대입(DB로부터 받아온 프로필 이미지의 바이트 배열)
        }
        // 'User.ModifyProfile.cs'에서 사용되며, 프로필 이미지, 비밀번호를 같이 바꿀때 사용되는 메소드
        public void UpdateUserInformation(string nick, string name, string email, string phone_number, string birthday, string gender, string address, string password, byte[] image) // 인자값 닉네임, 이름, 이메일, 전화번호, 생일, 성별, 주소, 비밀번호, 프로필 이미지
        {
            this.Nickname = nick; // 객체의 Nickname 프로퍼티에 문자열 nick을 대입(DB로부터 받아온 닉네임)
            this.Name = name; // 객체의 Name 프로퍼티에 문자열 name을 대입(DB로부터 받아온 이름)
            this.Email = email; // 객체의 Email 프로퍼티에 문자열 email을 대입(DB로부터 받아온 이메일)
            this.PhNum = phone_number; // 객체의 PhNum 프로퍼티에 문자열 phone_number를 대입(DB로부터 받아온 전화번호)
            this.Birthday = birthday; // 객체의 birthday 프로퍼티에 문자열 birthday를 대입(DB로부터 받아온 생일)
            this.Gender = gender; // 객체의 gender 프로퍼티에 문자열 gender를 대입(DB로부터 받아온 성별)
            this.Address = address; // 객체의 Address 프로퍼티에 문자열 address를 대입(DB로부터 받아온 주소)
            this.Password= password; // 객체의 Password 프로퍼티에 문자열 password를 대입(비밀번호)
            this.Profile = image; // 객체의 Profile 프로퍼티에 바이트 배열 image를 대입(DB로부터 받아온 프로필 이미지의 바이트 배열)
        }
        // 'User.ModifyProfile.cs'에서 사용되며, 정보 수정을 할때 사용되는 메소드
        public void UpdateUserInformation(string nick, string name, string email, string phone_number, string birthday, string gender, string address) // 인자값 닉네임, 이름, 이메일, 전화번호, 생일, 성별, 주소
        {
            this.Nickname = nick; // 객체의 Nickname 프로퍼티에 문자열 nick을 대입(DB로부터 받아온 닉네임)
            this.Name = name; // 객체의 Name 프로퍼티에 문자열 name을 대입(DB로부터 받아온 이름)
            this.Email = email; // 객체의 Email 프로퍼티에 문자열 email을 대입(DB로부터 받아온 이메일)
            this.PhNum = phone_number; // 객체의 PhNum 프로퍼티에 문자열 phone_number를 대입(DB로부터 받아온 전화번호)
            this.Birthday = birthday; // 객체의 birthday 프로퍼티에 문자열 birthday를 대입(DB로부터 받아온 생일)
            this.Gender = gender; // 객체의 gender 프로퍼티에 문자열 gender를 대입(DB로부터 받아온 성별)
            this.Address = address; // 객체의 Address 프로퍼티에 문자열 address를 대입(DB로부터 받아온 주소)
        }

        // 'User.ModifyProfile.cs'에서 사용되며, 비밀번호도 바꿀때 사용되는 메소드
        public void UpdateUserInformation(string nick, string name, string email, string phone_number, string birthday, string gender, string address, string password) // 인자값 닉네임, 이름, 이메일, 전화번호, 생일, 성별, 주소, 비밀번호
        {
            this.Nickname = nick; // 객체의 Nickname 프로퍼티에 문자열 nick을 대입(DB로부터 받아온 닉네임)
            this.Name = name; // 객체의 Name 프로퍼티에 문자열 name을 대입(DB로부터 받아온 이름)
            this.Email = email; // 객체의 Email 프로퍼티에 문자열 email을 대입(DB로부터 받아온 이메일)
            this.PhNum = phone_number; // 객체의 PhNum 프로퍼티에 문자열 phone_number를 대입(DB로부터 받아온 전화번호)
            this.Birthday = birthday; // 객체의 birthday 프로퍼티에 문자열 birthday를 대입(DB로부터 받아온 생일)
            this.Gender = gender; // 객체의 gender 프로퍼티에 문자열 gender를 대입(DB로부터 받아온 성별)
            this.Address = address; // 객체의 Address 프로퍼티에 문자열 address를 대입(DB로부터 받아온 주소)
            this.Password = password; // 객체의 Password 프로퍼티에 문자열 password를 대입(비밀번호)
        }

        // 연산자 중복, 객체에 + 금액 을 연산 함으로써 유저의 Money 프로퍼티에 돈을 추가하는 연산자 중복
        public static User operator + (User us, ulong n) 
        {
            us.money += n; // 유저의 money 필드 값에서 += n 을 하여 돈을 추가
            return us; // 연산된 객체를 반환
        }

        // 연산자 중복, 객체에 - 금액 을 연산 함으로써 유저의 Money 프로퍼티에 돈을 빼는 연산자 중복
        public static User operator -(User us, ulong n)
        {
            us.money -= n; // 유저의 money 필드 값에서 -= n 을 하여 돈을 추가
            return us; // 연산된 객체를 반환
        }
    }
    public class Moderator : User // 관리자 클래스를 유저클래스로부터 상속을 받음
    {
        public bool moderator; // 멤버 변수인 bool형 moderator 를 선언
        public Moderator() : base() // 생성자를 실행, 부모 클래스에서 일반 생성자를 실행
        {
            this.moderator = true; // 멤버 변수인 moderator를 true로 설정
        }
        public Moderator(MySqlDataReader rdr) : base(rdr) // 생성자를 실행, 부모 클래스에서 rdr이 인자값으로 대입되는 생성자를 실행
        {
            this.moderator = true; // 멤버 변수인 moderator를 true로 설정
        }
        // 'Moderator.Home' 폼에서 유저 정보 수정 버튼을 눌렀을 때 실행되는 메소드(프로필을 변경 했을때 실행)
        public string RefixUser(string nickname, string name, string email, string phnum, string id, string pw, string birthday, string gender, string address, string filename, ulong money) // 인자값 닉네임, 이름, 이메일, 전화번호, 아이디, 비밀번호, 생일, 성별, 주소, 파일 위치, 돈을 입력
        {
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결되어 있는 DB를 오픈
                byte[] imageBt; // 프로필 이미지를 바이트 배열로 받을 바이트 배열 imageBt를 선언
                FileStream fstream = new FileStream(filename, FileMode.Open, FileAccess.Read); // 파일 스트림에 파일 위치를 열고, 읽기 모드로 오픈
                BinaryReader br = new BinaryReader(fstream); // 열린 파일을 이진 파일로 읽고 br에 대입
                imageBt = br.ReadBytes((int)fstream.Length); // br에서 바이트를 읽는 함수에 스트림의 길이를 정수형으로 대입하여 스트림의 길이만큼 바이트를 읽고 imageBt 배열에 대입
                br.Close(); // 바이트 리더 연결을 해제
                fstream.Close(); // 파일 스트림 연결을 해제
                string _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', PASSWORD = '{5}', GENDER = '{6}', ADDRESS = '{7}', MONEY = '{8}', PROFILE = @IMG WHERE ID = '{9}'", nickname, name, email, phnum, birthday,pw,gender,address, money, id); // 업데이트를 하는 쿼리문을 작성, 아이디에 입력된 값의 위치에 해당 정보들을 업데이트 시키는 쿼리문
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB에 실행시킬 수 있는 객체로 생성
                _command.Parameters.Add(new MySqlParameter("@IMG", imageBt)); // 쿼리문 객체에 파라미터를 지정하여 문자열 @IMG 위치에 imageBt의 배열 값을 대입
                _command.ExecuteNonQuery(); // _command로 쿼리문 객체 실행(정상 실행시 업데이트 성공)
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결 해제
                return string.Empty; // 에러가 없으므로 에러 메시지를 반환하지 않음. 공백을 반환
            }
            catch (Exception ex) // 예외처리 발생시
            {
                MYSQL.mysql.Close(); // MYSQL.mysql과 연결된 DB와 연결을 해제하고
                return ex.Message; // 예외처리 메세지를 반환 (ex는 Exception 이므로, 문자열 반환을 위해서는 ex.Message를 통해서 메세지만 반환)
            }
        }

        // 'Moderator.Home' 폼에서 유저 정보 수정 버튼을 눌렀을 때 실행되는 메소드(프로필 변경을 안했을때 실행)
        public string RefixUser(string nickname, string name, string email, string phnum, string id, string pw, string birthday, string gender, string address, ulong money) // 인자값으로 닉네임, 이름, 이메일, 전화번호, 아이디, 비밀번호, 생일, 성별, 주소, 돈을 입력
        {
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결되어 있는 DB를 오픈
                string _query = string.Format("UPDATE user SET NICKNAME = '{0}', NAME = '{1}', EMAIL = '{2}', PHONE_NUMBER = '{3}', BR_DAY = '{4}', PASSWORD = '{5}', GENDER = '{6}', ADDRESS = '{7}', MONEY = '{8}' WHERE ID = '{9}'",nickname,name,email,phnum,birthday,pw,gender,address,money,id);  // 업데이트를 하는 쿼리문을 작성, 아이디에 입력된 값의 위치에 해당 정보들을 업데이트 시키는 쿼리문
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql);  // 쿼리문을 MYSQL.mysql에 연결된 DB에 실행시킬 수 있는 객체로 생성
                _command.ExecuteNonQuery(); // _command로 쿼리문 객체 실행(정상 실행시 업데이트 성공)
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결 해제
                return string.Empty; // 에러가 없으므로 에러 메시지를 반환하지 않음.공백을 반환
            }
            catch(Exception ex) // 예외처리 발생시
            {
                MYSQL.mysql.Close(); // MYSQL.mysql과 연결된 DB와 연결을 해제하고
                return ex.Message; // 예외처리 메세지를 반환 (ex는 Exception 이므로, 문자열 반환을 위해서는 ex.Message를 통해서 메세지만 반환)
            }
        }
    }
    
    class MYSQL // MYSQL 클래스 생성
    {
        static string server = ""; // MySql 서버 주소 (스태틱)
        static int port = ; // MySql 서버 포트(스태틱)
        static string database = ""; // 접근할 데이터 베이스 이름(스태틱)
        static string id = ""; // MySql 아이디(스태틱) 해당 계정은 DB의 어드민 계정이 아닌 DB에서 권한 제한을 걸어놓은 유저 계정
        static string password = ""; // MySql 비밀번호(스태틱) 해당 계정은 DB의 어드민 계정이 아닌 DB에서 권한 제한을 걸어놓은 유저 계정
        static string connect = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", server, port, database, id, password); // connect에 연결할 서버의 주소, 포트, DB, 아이디, 비밀번호를 입력
        public static MySqlConnection mysql = new MySqlConnection(connect);// 명령어를 MySqlConnection 생성자에 대입하여 mysql 객체 생성. Open()시, 명령어를 실행하여 데이터베이스에 접속
    }
    internal static class Program // Program 클래스 생성
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread] // 표준 쓰레드
        static void Main() // 메인 함수
        {
            Application.EnableVisualStyles(); // 애플리케이션에 비주얼 스타일(색,글꼴,운영 체제 테마)을 사용
            Application.SetCompatibleTextRenderingDefault(false); // 응용 프로그램 전체에서 해당 컨트롤의 UseCompatibleTextRendering 속성에 대한 기본값을 설정하는데 사용, 값이 true: UseCompatibleTextRendering을 지원하는 새 컨트롤은 텍스트 렌더링에 GDI+ 기반 그래픽 클래스를 사용, false일 경우 새 컨트롤은 GDI 기반 TextRenderer 클래스를 사용
            Application.Run(new formSignIn()); // 폼 실행
        }
    }
}

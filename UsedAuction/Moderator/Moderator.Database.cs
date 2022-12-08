using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace deal_Program
{
    public partial class formDBCheck : Form
    {
        // [ 첫 실행 ]
        // 폼 생성자
        public formDBCheck()
        {
            InitializeComponent(); // 컨트롤을 배치
        }
        // 폼 로드시 실행
        private void formDBCheck_Load(object sender, EventArgs e)
        {
            cbboxMenu.SelectedIndex = 0; // 콤보박스에서 제일 첫 요소를 선택
        }

        // [ 버튼 및 기능 구현 ]
        // 만약 콤보박스의 값이 바뀐다면
        private void cbboxMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshDB(); // RefreshDB 메소드를 호출
        }


        // [ 실시간 갱신 ]
        // '새로고침' 버튼 구현부
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDB(); // RefreshDB 메소드 호출(DataGridView를 새로고침)
        }
        // 데이터베이스를 새로고침하는 함수
        private void RefreshDB()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() // 딕셔너리를 생성, 키와 값 둘다 string형, 객체는 keyValuePairs로 생성
            {
                {"카테고리","category" }, // "카테고리" 키, "category" 벨류
                {"관리자 계정","moderator" }, // "관리자 계정" 키, "moderator" 벨류
                {"경매물건" ,"object" }, // "경매물건" 키, "object" 벨류
                {"유저 계정", "user" } // "유저 계정" 키, "user" 벨류
            }; // {} 내부 값들로 선언
            string row = "*"; // 선택할 열을 모두 선택
            if (cbboxMenu.Text == "경매물건") // 만약 'DB 선택' 콤보박스의 선택된 값이 "경매물건"일 경우
            {
                row = "NO, CATEGORY, NAME, STARTMONEY, BUY_PRICE, BUY_DATE, UPLOAD_USER, END_AUCTION, TEXT, HIGHER_USER, HIGHER_MONEY, ISLIVE"; // 가져올 열 들을 선택, 매물은 최대 4개의 이미지를 읽게 되는데 너무 DB가 길어져서 확인이 어려울것 같아서 이미지 부분은 제외하고 설정
            }
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT {1} FROM {0};", keyValuePairs[cbboxMenu.Text],row);
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // _query를 MYSQL.mysql에 연결된 DB에 사용할 수 있는 쿼리문으로 객체화 시켜줌
                MySqlDataAdapter _da = new MySqlDataAdapter(_command); // 데이터 어뎁터를 통해, _command의 쿼리에서 나온 데이터를 한번에 다 받고, 연결을 끊어줌.
                DataTable _dt = new DataTable(); // 데이터 테이블 _dt를 선언하고 객체를 생성
                _da.Fill(_dt); // _dt 데이터 테이블에 _da 데이터 어댑터에서 나온 값들을 전부 복사
                dataGridDB.DataSource = _dt; // 데이터 그리드 뷰 DB에 데이터 소스를 _dt로 설정함으로써 DB를 보여줌
            }
            catch (Exception ex) // 예외 발생시
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결을 해제
                MessageBox.Show(ex.Message, "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 예외 메세지, 창 이름, OK버튼, Error 아이콘을 출력
            }
            finally // try, catch를 마치고 실행하는 파이널 구문
            {
                MYSQL.mysql.Close(); // MYSQL.mysql와 연결된 DB의 연결을 해제
            }
        }

        // [ 폼 종료 ]
        // '나가기'버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼을 닫기
        }
    }
}

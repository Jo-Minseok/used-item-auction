using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formAuctioning : Form
    {
        User user; // 멤버 변수 User의 객체인 user을 선언
        // [ 첫 실행 ]
        public formAuctioning(User us)
        {
            user = us; // user에 us를 대입
            InitializeComponent(); // 컨트롤을 배치
        }
        // 폼 로드시 실행
        private void formAuctioning_Load(object sender, EventArgs e)
        {
            timerRefresh.Tick += timerRefresh_Tick; // 새로고침 타이머 컴포넌트의 Tick 델리게이트에 timerRefresh_Tick의 함수를 저장
            timerRefresh.Start(); // 새로고침 타이머 시작(5초마다 반복)
            this.ActiveControl = radiobtnIng; // 라디오 버튼 '입찰중' 포커스
            this.Refresh(); // 새로고침 함수 실행
        }

        // [ 버튼 및 기능 구현 ]
        // '새로고침' 버튼 구현
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 멈춤
            this.Refresh(); // new로 재정의된 새로고침 함수 실행
            timerRefresh.Start(); // 타이머 실행
        }

        // 라디오 버튼의 체크가 바뀌었을 경우 실행
        private void radiobtnIng_CheckedChanged(object sender, EventArgs e)
        {
            this.Refresh(); // new로 재정의된 새로고침 함수 실행
        }

        // [ 실시간 갱신 ]
        // timerRefresh_Tick으로 새로고침 타이머 컴포넌트에 넣을 함수 생성
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            this.Refresh(); // new로 재정의된 새로고침 함수 실행
        }

        // new로 Refresh 함수를 재정의(새로고침)
        private new void Refresh() 
        {
            listViewAuction.Items.Clear(); // listViewAuction의 아이템들을 초기화 클리어
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB 오픈 
                string _query = string.Format("SELECT * FROM object WHERE ISLIVE = '{0}' AND HIGHER_USER = '{1}'", radiobtnIng.Checked ? 0 : 1, user.Id); // 문자열 쿼리문 작성, 라디오 버튼이 활성화 되어있다면 object(경매 물품) 테이블로부터 현재 입찰중에서 본인이 가장 최고 입찰자에 존재하는 것들을 받아옴, 활성화 되어있지 않으면 object(경매 물품) 테이블로부터 경매 결과에서 본인이 낙찰자가 된 결과들을 보여줌.
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // _command로 쿼리문, DB에 명령어를 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // _rdr에 _command를 실행하여 데이터를 받아옴
                ListViewItem newitem = new ListViewItem(); // 리스트 뷰 아이템 객체를 생성
                while (_rdr.Read()) // _rdr.Read()를 반복문으로, 읽어질때마다 실행, 즉, 0행이면 0번 실행, 10행이면 10번 실행
                {
                    newitem = new ListViewItem(new string[] { _rdr["END_AUCTION"].ToString(), _rdr["NAME"].ToString(), _rdr["CATEGORY"].ToString(), string.Format("{0:#,###}원", Convert.ToUInt64(_rdr["HIGHER_MONEY"].ToString())), string.Format("{0:#,###}원", Convert.ToUInt64(_rdr["STARTMONEY"].ToString())), _rdr["UPLOAD_USER"].ToString(), string.Format("{0:#,###}원", Convert.ToUInt64(_rdr["BUY_PRICE"].ToString())) }); // 새로운 아이템을 만들어주고
                    listViewAuction.Items.Add(newitem); // listViewAuction인 리스트 뷰의 아이템에 추가
                }
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외를 잡았을 경우
            {

                MYSQL.mysql.Close(); // MYSQL.mysql로 DB로부터 연결을 해제
                if (MessageBox.Show(ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 예외 메세지를 출력, 창 이름, 메세지 박스 버튼, 메세지 박스 아이콘(에러)를 출력하고 OK버튼을 눌렀을 경우
                {
                    this.Close(); // 해당 폼을 닫음
                }
            }
            finally // 불러와졌으면
            {
                MYSQL.mysql.Close(); // DB로부터 연결 해제
            }
        }

        // [ 폼 종료 ]
        // '나가기' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼을 닫기
        }

        // 폼이 닫힐때의 구현부
        private void formAuctioning_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop(); // 타이머 멈춤
        }
    }
}

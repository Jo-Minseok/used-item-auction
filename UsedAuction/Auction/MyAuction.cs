using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formMyAuction : Form
    {
        // 멤버 객체 user 선언
        User user;
        // [ 첫 실행 ]
        // 폼 생성자
        public formMyAuction(User user) // 생성자에서 User의 멤버 객체 user를 받아옴
        {
            InitializeComponent(); // 컨트롤을 배치
            this.user = user; // 멤버 객체 user에 생성자로 받은 user를 참조 대입
        }
        // 폼 로드시 실행
        private void formMyAuction_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnCancel; // '나가기'버튼에 포커스를 줌
            Refresh(); // 새로 재정의한 Refresh() 메소드를 실행
            timerRefresh.Tick += timerRefresh_Tick; // 새로고침 타이머 컴포넌트의 Tick 이벤트에 timerRefrsh_Tick 메소드를 추가
            timerRefresh.Start(); // 타이머 실행
        }

        // [ 버튼 및 기능 구현 ]
        // 새로고침 타이머 컴포넌트에 추가할 메소드
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            Refresh(); // 재정의한 Refresh 메소드를 실행
        }

        // Refresh 메소드를 재정의 
        private new void Refresh()
        {
            listViewMyAuction.Items.Clear(); // 리스트뷰의 아이템들을 클리어 시킴
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * FROM user"); // 쿼리문을 작성, 유저 테이블의 모든 행을 선택
                MySqlDataAdapter adapter = new MySqlDataAdapter(_query, MYSQL.mysql); // 쿼리문을 실행하여 데이터 어댑터에 데이터를 한번에 받고 연결을 끊음
                DataTable ds = new DataTable(); // 데이터 테이블 ds를 선언하고 객체를 생성
                MySqlCommand _command; // 실질적 쿼리문을 실행할 객체를 생성
                MySqlDataReader _rdr; // 데이터 리더를 선언
                adapter.Fill(ds); // 데이터 테이블 ds에 데이터 어뎁터의 데이터들을 복사
                _query = string.Format("SELECT * FROM object WHERE UPLOAD_USER = '{0}'", user.Id); // 쿼리문을 작성, 경매 매물 테이블에서 업로더가 본인인 데이터들을 선택
                _command = new MySqlCommand(_query, MYSQL.mysql); // MYSQL.mysql와 연결된 DB에 실질적으로 쿼리를 작성하는 객체를 생성
                _rdr = _command.ExecuteReader(); // 쿼리를 실행
                while (_rdr.Read()) // 한 행씩 읽어옴
                {
                    string address = string.Empty; // 주소 문자열을 공백으로 초기화
                    string phone_number = string.Empty; // 전화번호 문자열을 공백으로 초기화
                    DataRow[] dtkey = ds.Select("ID = '" + _rdr["HIGHER_USER"].ToString() + "'"); // dtkey를 배열 행으로 유저 테이블에서 아이디가 HIGHER_USER인 곳을 찾고
                    if (_rdr["ISLIVE"].ToString() == "1") // 만약 해당 경매 매물이 종료된 상태라면
                    {
                        if (_rdr["HIGHER_USER"].ToString() != string.Empty) // 만약 최고 입찰자가 존재할 경우
                        {
                            foreach (DataRow _dr in dtkey) // _dr의 데이터 행을 dtKey 배열안에서 반복을 진행
                            {
                                phone_number = _dr["PHONE_NUMBER"].ToString(); // 유저의 아이디에 정보를 찾았다면 해당 정보의 전화번호 열의 값을 문자열로 받아옴
                                address = _dr["ADDRESS"].ToString(); // 유저의 아이디에 정보를 찾았다면 해당 정보의 주소 열의 값을 문자열로 받아옴
                            }
                        }
                    }
                    else // 해당 경매 매물이 종료되지 않은 상태라면
                    {
                        if (_rdr["HIGHER_USER"].ToString()!=string.Empty) // 만약 최고 입찰자가 존재할 경우
                        {
                            address = "(낙찰시 공개)"; // 주소 문자열에 개인정보 보호를 위해 (낙찰시 공개) 문자열을 대입
                            phone_number = "(낙찰시 공개)"; // 주소 문자열에 개인정보 보호를 위해 (낙찰시 공개) 문자열을 대입
                        }
                    }
                    ListViewItem newitem = new ListViewItem(new string[] { _rdr["NAME"].ToString(), string.Format("{0:#,##0}", _rdr["STARTMONEY"]), string.Format("{0:#,##0}", _rdr["HIGHER_MONEY"]), _rdr["HIGHER_USER"].ToString(), address, phone_number, _rdr["END_AUCTION"].ToString() }); // 리스트 뷰 아이템의 객체를 생성하고 내부에서 문자열 배열에 맞게 아이템 객체를 생성
                    if (_rdr["ISLIVE"].ToString() == "0") // 만약 매물이 경매중이면은
                    {
                        newitem.ForeColor = System.Drawing.Color.Green; // 아이템의 글씨 색깔을 초록색으로 설정
                    }
                    else // 아닐 경우
                    {
                        newitem.ForeColor = System.Drawing.Color.Black; // 아이템의 글씨 색깔을 검정색으로 설정
                    }
                    listViewMyAuction.Items.Add(newitem); // 리스트 뷰에 아이템을 추가
                }
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외처리 메세지, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch 이후에 finally 구문
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
            }
        }

        // '새로고침' 버튼 구현부
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 멈춤
            Refresh(); // 재정의한 새로고침 메소드 실행
            timerRefresh.Start(); // 타이머 시작
        }

        // [ 폼 종료 ]
        // 폼을 종료할시
        private void formMyAuction_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop(); // 새로고침 타이머를 멈춤
        }
        // '나가기' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼을 닫는다.
        }
    }
}

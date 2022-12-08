using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace deal_Program
{
    public partial class formUScash : Form
    {
        User _user; // _user 객체를 선언, 폼의 멤버 변수로 선언

        // [ 첫 실행 ]
        // 폼 생성자
        public formUScash(User us)
        {
            _user = us; // 홈 폼에서부터 us의 객체를 받아와서 _user에 대입
            InitializeComponent(); // 컨트롤을 배치
        }
        // 폼 로드 구현부
        private void formUScash_Load(object sender, EventArgs e)
        {
            txtboxAvaMoney.Text = _user.Money.ToString(); // '입찰 가능 금액' 텍스트 박스의 문자열을 _user 객체의 Money 프로퍼티로부터 값을 받아와 문자열 형식으로 처리
            this.ActiveControl = cbboxBank; // 폼의 집중 부분을 콤보박스 '은행' 부분으로 설정
            this.Refresh(); // Refresh를 new로 재정의 한 함수를 호출
            timerRefresh.Tick += timerRefresh_Tick; // 새로고침 타이머의 Tick 델리게이트에 timerRefresh_Tick 함수를 더해줌
            timerRefresh.Start(); // 타이머 시작
        }

        // [ 버튼 및 기능 구현 ]
        // '입금' 버튼 구현부
        private void btnInCash_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 스탑
            if (!cbboxBank.Items.Contains(cbboxBank.Text)) // 만약 은행이 존재하지 않다면
            {
                if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { // 만약 메세지 박스에서 OK버튼을 눌렀을 경우
                    cbboxBank.SelectedIndex = 0; // 콤보박스의 0번째 요소를 선택하게 되고
                    return; // 해당 함수를 종료
                }
            }
            if (cbboxBank.SelectedIndex != -1 || cbboxBank.Items.Contains(cbboxBank.Text)) // 콤보박스의 아이템이 선택되었을 경우 또는 텍스트 입력한게 콤보 박스 안의 요소로 존재할 경우
            {
                if (txtboxCharge.Text != string.Empty && txtboxCharge.Text != "0" && (ulong.Parse(txtboxCharge.Text, System.Globalization.NumberStyles.AllowThousands) <= 10000000)) // '금액'의 텍스트 박스가 비었지 않았고, 텍스트 박스의 문자열의 제일 앞 문자열이 0일 경우, 금액을 올바르게 입력했을 경우
                {
                    if (MessageBox.Show(string.Format("{0}원을 충전하시겠습니까?", txtboxCharge.Text), "충전", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // 메세지 박스의 버튼을 Yes 를 눌렀을 경우
                    {
                        try
                        {
                            MYSQL.mysql.Open(); // MYSQL.mysql의 DB를 오픈하고
                            _user += ulong.Parse(txtboxCharge.Text, System.Globalization.NumberStyles.AllowThousands); // 연산자 중복을 통해서 텍스트 박스의 문자열을 3자리 ,를 unsigned long 형으로 바꾼 후 _user에 더해줌
                            string _query = string.Format("UPDATE user SET MONEY = '{0}' WHERE ID = '{1}'", _user.Money, _user.Id); // 쿼리문을 작성(유저의 돈을 갱신해주는 쿼리)
                            txtboxAvaMoney.Text = _user.Money.ToString(); // 입찰 가능 금액의 텍스트 박스에 유저의 돈을 문자열 형식으로 받아서 대입
                            MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql의 DB에 쿼리문 객체로 생성
                            _command.ExecuteNonQuery(); // 쿼리문을 실행
                            MessageBox.Show("계좌 충전을 완료하였습니다!", "충전", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // 메세지 박스를 출력
                            txtboxTotalMoney.Text = (_user.Money + ulong.Parse(txtboxAuctionMoney.Text, System.Globalization.NumberStyles.AllowThousands)).ToString(); // '총 금액' 텍스트 박스에 유저의 돈 + 입찰중인 금액의 합한 금액을 출력
                            txtboxCharge.Text = string.Empty; // '금액' 텍스트 박스의 텍스트를 공백으로 설정
                        }
                        catch (Exception ex) // 예외처리
                        {
                            MessageBox.Show(ex.Message, "사용자 계좌 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 예외처리 문구를 출력
                        }
                        finally // try또는 catch문의 마지막으로
                        {
                            MYSQL.mysql.Close(); // MYSQL.mysql의 DB랑 연결 해제
                        }
                        return; // return을 통해서 함수 종료
                    }
                }
                else
                {
                    MessageBox.Show("금액을 잘못 입력 하였습니다.\n최대 1회 충전 금액은 1000만원입니다.", "계좌 입금 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // '금액'의 텍스트 박스가 비었지 않았고, 텍스트 박스의 문자열의 제일 앞 문자열이 0일 경우, 금액을 올바르게 입력했을 경우의 조건에 부합하지 않을 경우 메세지 박스를 출력
                    this.txtboxCharge.Focus(); // '금액' 텍스트 박스에 포커스를 둠

                }
            }
            else // 만약 콤보박스에서 선택이 안되어있거나 입력한 텍스트가 아이템에 없을 경우
            {
                MessageBox.Show("은행을 선택하지 않았습니다.", "계좌 입금 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력하고
                this.cbboxBank.Focus(); // 콤보박스에 집중을 줌
            }
            timerRefresh.Start(); // 타이머 스타트
        }
        // '출금' 버튼 구현부
        private void btnOutCash_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 스탑
            if (!cbboxBank.Items.Contains(cbboxBank.Text)) // cbboxBank.Text은행이 존재하지 않기 때문에
            {
                if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 만약 메세지 박스를 출력하는데 OK버튼을 눌렀을 경우
                {
                    cbboxBank.SelectedIndex = 0; // 콤보박스의 0번째 인덱스를 선택
                    return; // 함수 종료
                }
            }
            if (cbboxBank.SelectedIndex != -1 || cbboxBank.Items.Contains(cbboxBank.Text)) // 콤보박스의 아이템이 선택되었을 경우 또는 텍스트 입력한게 콤보 박스 안의 요소로 존재할 경우
            {
                if (txtboxCharge.Text != string.Empty && txtboxCharge.Text != "0" && ulong.Parse(txtboxCharge.Text, System.Globalization.NumberStyles.AllowThousands) < _user.Money) // 만약 '금액' 텍스트 박스의 텍스트가 비었지 않았고, '금액' 텍스트 박스의 텍스트가 0이 아니면서 유저의 금액보다 적을 경우
                {

                    if (MessageBox.Show(string.Format("{0}원을 출금하시겠습니까?", txtboxCharge.Text), "출금", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // 만약 메세지 박스로부터 Yes 버튼을 눌렀다면
                    {
                        try
                        {
                            MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈하고
                            _user -= ulong.Parse(txtboxCharge.Text, System.Globalization.NumberStyles.AllowThousands); // 연산자 중복을 통해서 텍스트 박스의 문자열을 3자리 ,를 unsigned long 형으로 바꾼 후 _user에 빼줌
                            string _query = string.Format("UPDATE user SET MONEY = '{0}' WHERE ID = '{1}'", _user.Money, _user.Id); // 쿼리문을 작성(유저의 돈을 갱신해주는 쿼리)
                            txtboxAvaMoney.Text = _user.Money.ToString(); // 입찰 가능 금액의 텍스트 박스에 유저의 돈을 문자열 형식으로 받아서 대입
                            MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql의 DB에 쿼리문 객체로 생성
                            _command.ExecuteNonQuery(); // 쿼리문을 실행
                            MessageBox.Show("계좌 출금을 완료하였습니다!", "출금", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // 메세지 박스를 출력
                            txtboxTotalMoney.Text = (_user.Money + ulong.Parse(txtboxAuctionMoney.Text, System.Globalization.NumberStyles.AllowThousands)).ToString(); // 총 금액 텍스트 박스에 유저의 돈 + 입찰중인 금액을 더한 값을 문자열로 바꾼 후 대입
                            txtboxCharge.Text = string.Empty; // '금액' 텍스트 박스의 텍스트를 공백으로 설정
                        }
                        catch (Exception ex) // 예외 처리
                        {
                            MessageBox.Show(ex.Message, "사용자 계좌 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력
                        }
                        finally // try 또는 catch문의 마지막으로 실행
                        {
                            MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
                        }
                        return; // 함수 종료
                    }
                }
                else // 만약 '금액' 텍스트 박스의 텍스트가 비었지 않았고, '금액' 텍스트 박스의 텍스트가 0이 아니면서 유저의 금액보다 적을 경우의 조건에 부합되지 않는다면
                {
                    MessageBox.Show("금액을 잘못 입력 하였습니다.", "계좌 출금 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력
                    this.txtboxCharge.Focus(); // '금액' 텍스트 박스에 중점을 줌
                }
            }
            else // 만약 콤보박스에서 선택이 안되어있거나 입력한 텍스트가 아이템에 없을 경우
            {
                MessageBox.Show("은행을 선택하지 않았습니다.", "계좌 입금 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력하고
                this.cbboxBank.Focus(); // 콤보박스에 집중을 줌
            }
            timerRefresh.Start(); // 타이머 시작
        }
        // '금액' 숫자만 입력 가능 텍스트 박스 구현부
        private void txtboxCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 만약 입력된 키가 백스페이스 이거나 숫자가 아닐 경우
            {
                e.Handled = true; // 이벤트를 처리했다고 인식하여 입력을 하지 않음.
            }
        }
        // '금액' 텍스트 박스에 3자리마다 ','로 출력하는 메소드
        private void txtboxCharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ulong text = ulong.Parse(txtboxCharge.Text, NumberStyles.AllowThousands); // text에 텍스트 박스의 숫자를 3자리마다 , 넣은걸 빼고, long형으로 대입 
                txtboxCharge.Text = string.Format("{0:#,##0}", text); // '금액' 텍스트 박스의 출력을 3자리 ,로 출력
                txtboxCharge.SelectionStart = txtboxCharge.Text.Length; // '금액' 텍스트 박스의 시작 위치를 '금액' 텍스트 박스의 텍스트 길이에 시작
            }
            catch (Exception) // 텍스트박스에서 숫자가 없을 경우 (다 지워버렸을때)
            {
                txtboxCharge.Text = "0"; // 0으로 처리
            }
        }
        // '총 금액' 텍스트 박스에 3자리마다 ','로 출력하는 메소드
        private void txtboxTotalMoney_TextChanged(object sender, EventArgs e)
        {
            txtboxTotalMoney.Text = string.Format("{0:#,##0}", ulong.Parse(txtboxTotalMoney.Text, System.Globalization.NumberStyles.AllowThousands)); // 총 금액 텍스트 박스의 텍스트의 포맷 형식을 3자리 ,로 설정
        }
        // '입찰 중 금액' 텍스트 박스에 3자리마다 ','로 출력하는 메소드
        private void txtboxAuctionMoney_TextChanged(object sender, EventArgs e)
        {
            txtboxAuctionMoney.Text = string.Format("{0:#,##0}", ulong.Parse(txtboxAuctionMoney.Text,System.Globalization.NumberStyles.AllowThousands)); // 입찰중인 텍스트 박스의 텍스트의 포맷 형식을 3자리 ,로 설정
        }
        // '입찰 가능 금액' 텍스트 박스에 3자리마다 ','로 출력하는 메소드
        private void txtboxAvaMoney_TextChanged(object sender, EventArgs e)
        {
            txtboxAvaMoney.Text = string.Format("{0:#,##0}", _user.Money); // 입찰 가능 금액의 텍스트 박스의 텍스트의 포맷 형식을 3자리 ,로 설정
        }
        
        // [ 갱신 ]
        // 타이머 5초마다 작동하는 메소드
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            this.Refresh(); // new로 재정의한 Refresh 함수를 실행
        }
        // Refresh() 메소드를 new로 재정의하여 계좌 정보를 데이터 베이스를 통해서 받아오는 메소드
        private new void Refresh()
        {
            try
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 연결 해제
                ulong sum = 0; // unsigned long의 sum 변수를 선언 및 0으로 초기화
                string _query = string.Format("SELECT * FROM object WHERE HIGHER_USER = '{0}' AND ISLIVE = '{1}'", _user.Id, 0); // 쿼리문을 통해 데이터를 선택, _user.Id를 통해, 현재 경매가 활성화되어있는 목록을 선택
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리를 MySqlCommand에 쿼리 명령어로 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // 쿼리를 실행하여 _rdr에 데이터를 받아옴
                while (_rdr.Read()) // _rdr.Read로부터 읽어와진다면 반복
                {
                    sum += Convert.ToUInt64(_rdr["HIGHER_MONEY"].ToString()); // sum에 현재 유저가 최고가 입찰자인 경매물건의 최고금액을 다 더해줌
                }
                _rdr.Close(); // _rdr을 종료
                txtboxAuctionMoney.Text = sum.ToString(); // 입찰중인 텍스트 박스의 문자열을 입찰중인 변수를 문자열화 시켜서 대입 
                txtboxTotalMoney.Text = (ulong.Parse(txtboxAuctionMoney.Text, System.Globalization.NumberStyles.AllowThousands) + ulong.Parse(txtboxAvaMoney.Text, System.Globalization.NumberStyles.AllowThousands)).ToString(); // 총 금액의 텍스트를 입찰중인 금액 + 입찰 가능 금액을 더하여서 대입
            }
            catch (Exception ex) // 예외처리
            {
                MessageBox.Show(ex.Message, "계좌 로드 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력
            }
            finally // try, catch가 끝났을 경우 실행하는 파이널 문
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB 연결 해제
            }
        }

        // [ 폼 종료 ]
        // '나가기' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼을 닫음
        }
    }
}

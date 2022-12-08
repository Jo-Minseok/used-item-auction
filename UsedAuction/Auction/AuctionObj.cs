using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
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
using static System.Net.Mime.MediaTypeNames;

namespace deal_Program
{
    public partial class formAuctionobj : Form
    {
        User user; // 유저 객체 선언
        string no; // 문자열 no로 해당 경매 번호가 몇번인지 받아오는 문자열
        bool moderator; // bool moderator로 관리자인이 확인하는 변수
        // [ 첫 실행 ]
        // 폼 생성자
        public formAuctionobj(string no, bool moderator,User us)
        {
            user = us; // 유저 객체를 홈 폼에서부터 받아와서 대입
            this.no = no; // 해당 경매글이 몇번인지를 홈에서부터 받아와서 대입
            this.moderator = moderator; // 관리자 권한을 홈에서부터 받아와서 대입
            InitializeComponent(); // 컨트롤을 배치
            timerRefresh.Tick += timerRefresh_Tick; // 새로고침 타이머 컴포넌트의 Tick 델리게이트에 timerRefresh_Tick 함수를 추가
            timerRefresh.Start(); // 새로고침 타이머 시작
        }

        // 폼 로드시 실행
        private void formAuctionobj_Load(object sender, EventArgs e)
        {
            RefreshForm(); // 새로고침 폼 함수 실행
            this.ActiveControl = btnRefresh; // 폼 실행시 포커스가 되는 컨트롤러를 '새로고침' 버튼으로 설정
        }

        // [ 버튼 및 기능 구현 ]
        // '삭제' 버튼 구현부
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("삭제하시겠습니까?","게시글 삭제",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) // 메세지 박스를 출력, 내용, 폼 이름, 버튼, 질문 아이콘으로 출력하고 Yes를 누를 경우
            {
                try
                {
                    MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                    string _query = string.Format("SELECT * FROM object WHERE NO = '{0}'", no); // 쿼리문을 작성, 게시글 번호가 no인 데이터를 선택
                    MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // _command로 DB에 쿼리문을 실행시키기 위한 객체형식으로 생성
                    MySqlDataReader _rdr = _command.ExecuteReader(); // _rdr에 _command 를 실행함으로써 데이터를 받아옴
                    _rdr.Read(); // 한 행을 받고
                    string _highestUser = _rdr["HIGHER_USER"].ToString(); // 해당 게시글의 가장 최고가 유저의 정보를 문자열로 받고
                    ulong _highestPirce = Convert.ToUInt64(_rdr["HIGHER_MONEY"]); // 해당 게시글의 가장 최고가를 ulong 형식으로 받고
                    _rdr.Close(); // _rdr을 닫음
                    if (_highestUser != string.Empty) // 만약 최고가 유저가 존재한다면
                    {
                        _query = string.Format("UPDATE user SET MONEY = MONEY + '{0}' WHERE ID = '{1}'", _highestPirce, _highestUser); // 쿼리문을 작성, 최고가 유저에게 다시 돈을 넣어줘야하기 때문에 업데이트
                        _command = new MySqlCommand(_query, MYSQL.mysql); // _command로 DB에 쿼리문을 실행시키기 위한 객체형식으로 생성
                        _command.ExecuteNonQuery(); // 업데이트 쿼리문 실행
                    }
                    _query = string.Format("DELETE FROM object WHERE NO = '{0}'", no); // 쿼리문을 작성하고 해당 경매물건의 번호의 위치를 찾은 후 삭제
                    _command = new MySqlCommand(_query, MYSQL.mysql); // _command로 DB에 쿼리문을 실행시키기 위한 객체형식으로 생성
                    _command.ExecuteNonQuery(); // DELETE 쿼리문을 실행
                    timerRefresh.Stop(); // 타이머를 종료
                    MYSQL.mysql.Close(); // MYSQL로부터 연결 끊고
                    this.Close(); // 폼 닫기
                    MessageBox.Show("삭제 완료!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // 메세지 박스 출력, 내용, 창 이름, OK버튼, 아이콘(정보) 를 출력
                }
                catch(Exception ex) // 예외를 잡았을 경우
                {
                    MessageBox.Show(ex.Message, "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 내용(예외 내용), 창 이름, OK버튼, 아이콘(에러)를 출력
                }
                finally // try나 catch로 나와졌을때 마지막으로 실행
                {
                    MYSQL.mysql.Close(); // MYSQL.mysql로부터 연결 해제
                }
            }
        }
        // '+1000 입찰' 버튼 구현부
        private void btnPlus1000_Click(object sender, EventArgs e)
        {
            EnterAuction(1000); // EnterAuction에 1000을 대입하여 함수를 실행(입찰)
        }
        // '+5000 입찰' 버튼 구현부
        private void btnPlus5000_Click(object sender, EventArgs e)
        {
            EnterAuction(5000); // EnterAuction에 5000을 대입하여 함수를 실행(입찰)
        }
        // '+10000 입찰' 버튼 구현부
        private void btnPlus10000_Click(object sender, EventArgs e)
        {

            EnterAuction(10000); // EnterAuction에 10000을 대입하여 함수를 실행(입찰)
        }
        // '사용자 정의 입찰' 버튼
        private void btnUserPrice_Click(object sender, EventArgs e)
        {
            if(txtboxUserPrice.Text == string.Empty) // 만약 유저가 적은 금액이 비었을 경우
            {
                MessageBox.Show("금액을 입력하세요.","오류",MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력
                return; // 함수 종료
            }
            EnterAuction(ulong.Parse(txtboxUserPrice.Text,NumberStyles.AllowThousands)); // 텍스트 박스에 적어놓은 금액을 3자리 콤마를 뺀 형식의 문자열을 unsigned long형으로 변환 후 입찰에 참가
        }
        // 입찰 버튼 실질적 구현부
        private void EnterAuction(ulong money)
        {
            timerRefresh.Stop(); // 타이머 스탑
            try
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * FROM object WHERE ISLIVE = '0' AND NO = '{0}'", no); // 쿼리를 작성, 경매 물건 번호가 no이면서 현재 경매중인 경매 물건을 선택
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // MySqlDataReader의 _rdr에 _command의 쿼리문을 실행하여 출력되는 데이터 테이블을 저장
                _rdr.Read(); // _rdr을 통해서 1행을 받아옴
                if (!_rdr.HasRows) // 만약 행이 없다면
                {
                    _rdr.Close(); // _rdr의 연결을 해제하고
                    MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                    if (MessageBox.Show("해당 매물은 낙찰되었거나 삭제된 매물입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스를 출력하고, OK버튼을 누를 경우
                    {
                        this.Close(); // 해당 폼을 닫음
                    }
                    return; // return으로 해당 함수를 종료
                }
                string uploader = _rdr["UPLOAD_USER"].ToString(); // uploader의 문자열에 _rdr의 UPLOAD_USER 열로부터 문자열화 시켜서 대입
                ulong highestPrice = Convert.ToUInt64(_rdr["HIGHER_MONEY"]); // 최고가 변수에 _rdr의 HIGHER_MONEY열의 값을 Ulong으로 받아와서 highestPrice에 저장
                string highestUser = _rdr["HIGHER_USER"].ToString(); // highestUser 변수에 _rdr의 HIGHER_USER열의 값을 문자열로 변환하여 최고가 유저 변수에 저장
                _rdr.Close(); // _rdr의 데이터 리더 연결을 해제
                if (uploader == user.Id) // 업로더가 자신일 경우
                {
                    MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                    MessageBox.Show("본인이 업로드한 경매에는 참여할 수 없습니다!", "경매 참가 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 메세지 박스를 출력하여 본인이 업로드한 경매에는 참여할 수 없다는 것을 출력
                    RefreshForm(); // 경매 폼을 새로고침
                    timerRefresh.Start(); // 타이머 시작
                    return; // 함수를 종료
                }
                if (highestUser == user.Id) // 최고 입찰자가 본인일 경우
                {
                    if (user.Money < money) // 만약 유저(본인이면서 최고 입찰자)의 돈이 입찰하고자 하는 돈보다 작을 경우
                    {
                        MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                        MessageBox.Show("자산이 부족합니다!", "경매 참가 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 자금이 부족하다는 메세지 박스를 출력, 창 이름은 경매 참가 오류, 메세지 박스 버튼 OK, 메세지 박스 아이콘은 Warning(경고)
                        RefreshForm(); // 폼을 새로 고침
                        return; // 함수를 종료
                    }
                    _query = string.Format("UPDATE object SET HIGHER_MONEY = '{0}' WHERE NO = '{1}'", highestPrice + money, no); // 업데이트 하는 쿼리문을 작성, 최고가 + money를 통해 본인이 올린 최고가에 + 금액을 하여, 경매 게시글의 번호에 업데이트
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    user -= money; // user 객체에 연산자 중복을 통해 money만큼 사용자 계좌에서 출금을 해줌
                    _query = string.Format("UPDATE user SET MONEY = '{0}' WHERE ID = '{1}'", user.Money, user.Id); // 업데이트 하는 쿼리문을 작성, user.Money 를 유저 아이디에 업데이트 시켜줌
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    _query = string.Format("UPDATE user SET COUNT_IN_AUCTION = COUNT_IN_AUCTION + 1 WHERE ID = '{0}'", user.Id);
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                    if (MessageBox.Show("경매 참여에 성공하였습니다!\n좋은 결과가 있길 바랍니다.", "경매 참가 성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK) // 메세지 박스를 출력
                    {
                        RefreshForm(); // 폼을 새로 고침
                    }
                    timerRefresh.Start(); // 타이머 시작
                    return; // 함수 종료
                }
                else // 최고 입찰자가 본인이 아닐 경우
                {
                    if (user.Money < highestPrice + money) // 만약 유저 돈이 최고금액 + 입찰 추가금액만큼 없을 경우 
                    {
                        MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                        MessageBox.Show("본인의 자산보다 많은 돈을 경매에 참여시킬 수 없습니다!", "경매 참가 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 메세지 박스를 출력 
                        RefreshForm(); // 경매 폼을 새로고침
                        return; // 함수를 종료
                    }
                    _query = string.Format("UPDATE user SET MONEY = MONEY + '{0}' WHERE ID = '{1}'", highestPrice, highestUser); // 쿼리문을 작성, 최고가 유저의 위치의 돈에 최고금액을 더해줌. 이렇게 할 경우, 밀려난 유저의 돈이 추가 됨
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    _query = string.Format("UPDATE object SET HIGHER_USER = '{0}', HIGHER_MONEY = '{1}' WHERE NO = '{2}'", user.Id, highestPrice + money, no); // 쿼리문을 작성, 게시글의 최고금액 입찰자를 본인으로, 최고금액을 본인이 입찰한 금액으로, 게시글 위치는 no로 설정
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    user -= highestPrice + money; // user 객체에 연산자 중복을 통해 money + 최고가 만큼 사용자 계좌에서 출금을 해줌
                    _query = string.Format("UPDATE user SET MONEY = '{0}' WHERE ID = '{1}'", user.Money, user.Id); // 쿼리문을 작성, DB에 있는 유저의 돈을 갱신
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    _query = string.Format("UPDATE user SET COUNT_IN_AUCTION = COUNT_IN_AUCTION + 1 WHERE ID = '{0}'", user.Id); // 쿼리문을 작성, 입찰 횟수를 + 1 시켜줌
                    user.CountInAuction += 1;
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    MYSQL.mysql.Close(); // MYSQL.mysql의 DB와 연결을 해제
                    if (MessageBox.Show("경매 참여에 성공하였습니다!\n좋은 결과가 있길 바랍니다.", "경매 참가 성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK) // 메세지 박스 출력, OK 버튼을 눌렀을 경우
                    {
                        RefreshForm(); // 경매창을 새로고침
                    }
                    timerRefresh.Start(); // 타이머 시작
                    return; // 함수를 종료
                }

            }
            catch (Exception ex) // 예외처리
            {
                MessageBox.Show(ex.Message, "경매 참가 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외 처리 메세지를 출력, 창 이름, 메세지 박스 버튼을 OK로 설정, 메세지 박스 아이콘(에러)로 출력
            }
            finally // try, catch의 끝으로 실행하는 구문
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB 연결을 해제
            }
        }
        // 낙찰 버튼
        private void btnEndAuction_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 멈춤
            if(labelHighestUser.Text == "입찰자 없음") // '최고 입찰자' 의 텍스트가 "입찰자 없음"일 경우
            {
                MessageBox.Show("입찰자가 존재하지 않아서 낙찰을 진행할 수 없습니다.\n삭제를 부탁드립니다.", "낙찰 불가능", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 낙찰을 할 수 없기 때문에 메세지 박스 출력
                timerRefresh.Start(); // 타이머 시작
                return; // 함수 종료
            }
            if(MessageBox.Show("낙찰을 진행하시겠습니까?","낙찰 확인",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) // 메세지 박스 출력을 했을때, Yes를 눌렀을 경우
            {
                try
                {
                    MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                    string _query = string.Format("SELECT * FROM object WHERE ISLIVE = '0' AND NO = '{0}'", no); // 쿼리를 작성, 현재 경매중인 그리고 NO가 게시글 번호인걸 선택
                    MySqlCommand _command = new MySqlCommand(_query,MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    MySqlDataReader _rdr = _command.ExecuteReader(); // 데이터 리더 _rdr에서 _command에서 실행하여 나온 _rdr의 데이터 리더에 저장
                    _rdr.Read(); // _rdr에서 한 행을 읽음.
                    if (!_rdr.HasRows) // _rdr에 행이 없다면
                    {
                        _rdr.Close(); // _rdr의 연결을 해제
                        MYSQL.mysql.Close(); // MYSQL.mysql의 연결을 해제
                        if (MessageBox.Show("이미 낙찰된 매물입니다.", "낙찰 오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스 출력, 내용, 창 이름, 메세지 박스 버튼을 OK로 설정, 메세지 박스 아이콘을 Error(오류)로 출력, OK를 누를 경우
                        {
                            this.Close(); // 창을 닫음.
                        }
                        return; // 함수 종료
                    }
                    ulong highestMoney = Convert.ToUInt64(_rdr["HIGHER_MONEY"]); // 최고 금액을 _rdr의 HIGHER_MONEY열의 값으로부터 ulong 형식으로 변환 후 대입
                    string highestUser = _rdr["HIGHER_USER"].ToString(); // highestUser 문자열에 _rdr의 HIGHER_USER열의 값을 문자열로 변환 후 대입
                    _rdr.Close(); // _rdr의 연결 해제
                    _query = string.Format("UPDATE object SET ISLIVE = 1 WHERE NO = '{0}'", no); // 쿼리문을 작성, 작성 게시글의 no가 있는 위치의 경매 글을 마감시킴.
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    _query = string.Format("UPDATE user SET MONEY = MONEY + {0} WHERE ID = '{1}'",highestMoney, user.Id); // 쿼리문을 작성, 게시글 작성자 본인의 금액에 최고금액을 더해줌으로써 판매 완료
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    _query = string.Format("UPDATE user SET COUNT_SUC_AUCTION = COUNT_SUC_AUCTION + 1 WHERE ID = '{0}'", highestUser); // 쿼리문을 작성, 최고 입찰자의 낙찰 횟수에 +1을 더해줌
                    _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                    _command.ExecuteNonQuery(); // 쿼리문을 실행
                    MessageBox.Show("낙찰을 완료하였습니다.","성공",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); // 메세지 박스 출력
                }
                catch (Exception ex) // 예외
                {
                    MessageBox.Show(ex.Message, "낙찰 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 예외 메세지를 출력, 메세지 박스로 창 이름, 버튼, 메세지 박스 아이콘 순서로 출력
                }
                finally
                {
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB 연결을 해제
                }
                this.Close(); // 폼 닫기
                return; // 함수 종료
            }
            timerRefresh.Start(); // 타이머 시작
        }
        // 텍스트 박스에 숫자만 입력되게 하는 이벤트
        private void txtboxUserPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 만약 입력된 키가 백스페이스 이거나 숫자가 아닐 경우
            {
                e.Handled = true; // 이벤트를 처리했다고 인식하여 입력을 하지 않음.
            }
        }
        // 텍스트 박스에 숫자 입력시 자동 , 입력되는 이벤트
        private void txtboxUserPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ulong text = ulong.Parse(txtboxUserPrice.Text,NumberStyles.AllowThousands); // text에 텍스트 박스의 숫자를 3자리마다 , 넣은걸 빼고, long형으로 대입 
                txtboxUserPrice.Text = string.Format("{0:#,##0}", text); // '사용자 정의 입찰' 텍스트 박스의 출력을 3자리 ,로 출력
                txtboxUserPrice.SelectionStart = txtboxUserPrice.Text.Length; // '사용자 정의 입찰' 텍스트 박스의 시작 지점을 '사용자 정의 입찰' 텍스트 박스의 텍스트 길이의 위치로 설정 즉, 마지막으로 설정
            }
            catch (Exception) // 예외처리(숫자를 다 지워버렸을 경우)
            {
                txtboxUserPrice.Text = "0"; // '사용자 정의 입찰' 텍스트 박스의 문자열을 "0"으로 출력
            }
        }

        // [ 실시간 갱신 ]
        // 폼 갱신 메소드
        private void RefreshForm()
        {
            try
            {
                string Writer; // 문자열 Writer(업로더) 선언
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * FROM object WHERE ISLIVE = '0' AND NO = '{0}'", no); // 쿼리 작성, 현재 경매중이며, 게시글 번호가 no인 것을 선택
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // 데이터 리더 _rdr에 _command를 실행했을때 나오는 데이터 테이블을 대입
                _rdr.Read(); // _rdr의 한 행을 읽음
                if (!_rdr.HasRows) // _rdr을 읽었을때, 행이 없다면
                {
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결 해제
                    _rdr.Close(); // _rdr 연결 해제
                    if (MessageBox.Show("해당 매물은 낙찰되었거나 삭제된 매물입니다.", "경매창 오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 메세지 박스 출력, OK 버튼을 눌렀을 경우
                    {
                        this.Close(); // 해당 폼을 종료
                    }
                    return; // 함수 종료
                }
                labelCategory.Text = _rdr["CATEGORY"].ToString(); // 카테고리 라벨에 _rdr의 CATEGORY 열에 있는 값을 문자열화 시키고 대입
                labelHighestprice.Text = string.Format("{0:#,##0} 원", _rdr["HIGHER_MONEY"]); // 최고가 라벨에 _rdr의 HIGHER_MONEY 열에 있는 값을 문자열화 시키고 대입
                labelStartprice.Text = string.Format("{0:#,##0} 원", _rdr["STARTMONEY"]); // 시작금액 라벨에 _rdr의 STARTMONEY 열에 있는 값을 문자열화 시키고 대입
                labelHighestUser.Text = _rdr["HIGHER_USER"].ToString() == string.Empty ? "입찰자 없음" : _rdr["HIGHER_USER"].ToString(); // 최고가 입찰자 라벨에 _rdr의 HIGHER_USER 열에 있는 값을 문자열화 시키고, 해당 문자열이 string.Empty으로 비었다면 "입찰자 없음"으로 설정하고 아닐 경우, 최고가 입찰자로 설정
                labelName.Text = _rdr["NAME"].ToString(); // 이름 라벨에 _rdr의 NAME 열에 있는 값을 문자열화 시켜서 제품의 이름을 대입
                this.Text = "매물 : " + _rdr["NAME"].ToString(); // 폼 이름을 "매물 : 제품 이름" 으로 설정
                Writer = _rdr["UPLOAD_USER"].ToString(); // 업로더 변수에 _rdr의 UPLOAD_USER 열에 있는 값을 문자열화 시켜서 대입(업로더 아이디)
                labelBuyprice.Text = string.Format("{0:#,##0} 원", _rdr["BUY_PRICE"]); // 구매 금액 라벨에 _rdr의 BUY_PRICE 열에 있는 값을 문자열화 포맷에 맞게 문자열 생성
                labelBuydate.Text = string.Format("{0}-{1}-{2}", Convert.ToDateTime(_rdr["BUY_DATE"]).Year, Convert.ToDateTime(_rdr["BUY_DATE"]).Month, Convert.ToDateTime(_rdr["BUY_DATE"]).Day); // 구매 날짜의 라벨에 문자열 포맷 형식에 맞게 문자열을 생성, _rdr의 "BUY_DATE"의 값을 날짜 형식으로 바꾸고, 날짜의 년, 월, 일을 출력
                labelEndDate.Text = _rdr["END_AUCTION"].ToString(); // 마감 일자의 라벨에 _rdr의 END_AUCTION 열의 값을 문자열화 시켜서 저장
                txtboxExplan.Text = _rdr["TEXT"].ToString(); // 설명 텍스트 박스에 _rdr의 TEXT 열의 값을 문자열화 시켜서 저장
                if (user.Id == Writer) // 만약 유저의 아이디가 업로더 아이디와 같다면
                {
                    btnRemove.Visible = true; // 삭제 버튼과
                    btnEndAuction.Visible = true; // 낙찰 버튼을 보이게 활성화
                }
                TimeSpan _LeftTime = Convert.ToDateTime(_rdr["END_AUCTION"]) - DateTime.Now; // TimeSpan으로 시간 간격을 계산할 수 있는 _LeftTIme이라는 객체를 생성하고, _rdr의 END_AUCTION 열의 값을 날짜화 시키고, 현재 시간을 뺀 값을 저장
                if (_LeftTime.TotalMinutes <= 30) // 남은 시간의 총 분이 30분 이하일 경우
                {
                    labelLeftTime.ForeColor = System.Drawing.Color.Red; // 남은 시간의 라벨 색을 빨강색으로 설정(마감임박)
                }
                labelLeftTime.Text = string.Format("{0}일 {1}시간 {2}분 {3}초", _LeftTime.Days, _LeftTime.Hours, _LeftTime.Minutes, _LeftTime.Seconds); // 남은 시간 라벨에 문자열 포맷에 맞게 남은 시간들을 출력, _LeftTime의 프로퍼티를 통하여 값을 받아옴.
                labelMoney.Text = string.Format("{0:#,##0} 원", user.Money); // 유저의 돈을 나타내는 라벨에 유저의 돈을 3자리마다 ,를 넣어서 출력

                byte[] image = null; // 이미지를 바이트 배열로 받을 image 변수 선언 및 null로 초기화
                image = (byte[])(_rdr["MAIN_PIC"]); // _rdr의 MAIN_PIC에 저장된 바이트 배열로 이루어진 값을 바이트 배열로 명시적 형 변환을 통해 image에 대입
                MemoryStream mstream = new MemoryStream(image); // 바이트 배열을 MemoryStream을 이용하여, 로컬 파일에 저장되지 않고 메모리에 저장되도록 실행 mstream에 대입하고
                pictureBoxObj.Image = System.Drawing.Image.FromStream(mstream); // 메모리 스트림에 저장된 바이트 배열을 이미지화 시켜서 픽처 박스(메인 이미지)에 대입
                mstream.Close(); // 메모리 스트림 종료
                if (_rdr["SUB_PIC1"].ToString() != string.Empty) // _rdr의 SUB_PIC1 열을 문자열화 시켰을때 값이 비었지 않았다면
                {
                    image = (byte[])(_rdr["SUB_PIC1"]); // _rdr의 SUB_PIC1에 저장된 바이트 배열로 이루어진 값을 바이트 배열로 명시적 형 변환을 통해 image에 대입
                    MemoryStream sub1 = new MemoryStream(image); // 바이트 배열을 MemoryStream을 이용하여, 로컬 파일에 저장되지 않고 메모리에 저장되도록 실행 sub1 에 대입하고
                    pictureboxSub1.Image = System.Drawing.Image.FromStream(sub1); // 메모리 스트림에 저장된 바이트 배열을 이미지화 시켜서 픽처 박스(서브 이미지1)에 대입
                    sub1.Close(); // sub1의 메모리 스트림을 닫음
                }
                else // string.Empty로 비었을 경우
                {
                    pictureboxSub1.Hide(); // 픽처박스 서브1 이미지를 숨김
                }
                if (_rdr["SUB_PIC2"].ToString() != string.Empty) // _rdr의 SUB_PIC2 열을 문자열화 시켰을때 값이 비었지 않았다면
                {
                    image = (byte[])(_rdr["SUB_PIC2"]); // _rdr의 SUB_PIC2에 저장된 바이트 배열로 이루어진 값을 바이트 배열로 명시적 형 변환을 통해 image에 대입
                    MemoryStream sub2 = new MemoryStream(image); // 바이트 배열을 MemoryStream을 이용하여, 로컬 파일에 저장되지 않고 메모리에 저장되도록 실행 sub2 에 대입하고
                    pictureboxSub2.Image = System.Drawing.Image.FromStream(sub2); // 메모리 스트림에 저장된 바이트 배열을 이미지화 시켜서 픽처 박스(서브 이미지2)에 대입
                    sub2.Close(); // sub2의 메모리 스트림을 닫음
                }
                else
                {
                    pictureboxSub2.Hide(); // 픽처박스 서브2 이미지를 숨김
                }
                if (_rdr["SUB_PIC3"].ToString() != string.Empty) // _rdr의 SUB_PIC3 열을 문자열화 시켰을때 값이 비었지 않았다면
                {
                    image = (byte[])(_rdr["SUB_PIC3"]); // _rdr의 SUB_PIC3에 저장된 바이트 배열로 이루어진 값을 바이트 배열로 명시적 형 변환을 통해 image에 대입
                    MemoryStream sub3 = new MemoryStream(image); // 바이트 배열을 MemoryStream을 이용하여, 로컬 파일에 저장되지 않고 메모리에 저장되도록 실행 sub3 에 대입하고
                    pictureboxSub3.Image = System.Drawing.Image.FromStream(sub3); // 메모리 스트림에 저장된 바이트 배열을 이미지화 시켜서 픽처 박스(서브 이미지3)에 대입
                    sub3.Close();// sub3의 메모리 스트림을 닫음
                }
                else
                {
                    pictureboxSub3.Hide(); // 픽처박스 서브3 이미지를 숨김
                }
                if (_rdr["SUB_PIC1"].ToString() == string.Empty && _rdr["SUB_PIC2"].ToString() == string.Empty && _rdr["SUB_PIC3"].ToString() == string.Empty) // _rdr의 SUB_PIC1,2,3 열의 값을 문자화하고, 비었을 경우 
                {
                    this.flowLayoutPanel1.Hide(); // flowLayoutPanel1을 숨김
                }
                if (Writer == user.Id) // 만약 업로더 아이디가 유저 아이디와 같다면 
                {
                    labelWriter.ForeColor = System.Drawing.Color.Blue; // 업로더 라벨의 글 색상을 파란색으로 설정
                }
                if (_rdr["HIGHER_USER"].ToString() == user.Id) // 만약 _rdr의 HIGHER_USER 열을 문자화한 값이 유저 아이디와 같다면
                {
                    labelHighestUser.ForeColor = System.Drawing.Color.Blue; // 최고 입찰자 글자 색을 파란색으로 설정
                    labelHighestUser.Text = "현재 최고 입찰자는 당신입니다!"; // 최고 입찰자 내용을 "현재 최고 입찰자는 당신입니다!"라고 설정
                }
                else // 최고 입찰자가 유저 아이디와 다르다면
                {
                    labelHighestUser.ForeColor = System.Drawing.Color.Black; // 최고 입찰자 글자 색을 검정색으로 설정
                }
                _rdr.Close(); // _rdr 연결 해제

                _query = string.Format("SELECT * FROM user WHERE ID = '{0}'", Writer); // 쿼리문을 작성, 업로더 아이디의 닉네임을 찾기 위한 쿼리
                _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리 명령어로 객체를 생성
                _rdr = _command.ExecuteReader(); // 쿼리문을 실행하여 user 테이블에서 업로더 아이디의 위치 데이터를 받아옴
                _rdr.Read(); // _rdr.Read()를 통해 한 행을 읽음. 
                labelWriter.Text = _rdr["NICKNAME"].ToString() + " (" + Writer + ")"; // 작성자 라벨을 닉네임(아이디) 형식으로 출력하게 설정, 닉네임은 바뀔 수 있지만 아이디는 바꿀 수 없다.
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외 처리
            {
                MessageBox.Show(ex.Message, "경매창 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 예외처리 메세지, 창 이름, OK버튼, Error아이콘으로 설정하여 출력
            }
            finally // try, catch에서 끝난 후 실행
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB로부터 연결을 끊음
            }
            if (moderator) // 만약 관리자로 봤을 경우
            {
                btnRemove.Visible = true; // 게시글 삭제 버튼이 보임.
            }
        }

        // 5초 새로고침 타이머에 저장할 메소드
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshForm(); // 폼 새로고침
        }

        // '새로고침' 버튼 구현부
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop(); // 타이머 멈춤
            RefreshForm(); // 폼 새로 고침
            timerRefresh.Start(); // 타이머 시작
        }

        // [ 폼 종료 ]
        // 폼을 종료할때 실행되는 메소드
        private void formAuctionobj_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop(); // 타이머 스탑
        }

        // '나가기' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼 닫기
        }

    }
}

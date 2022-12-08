using deal_Program;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace deal_Program
{
    // 유저 홈 폼
    public partial class formUShome : Form
    {
        int imageIndex = 0; // 로고 이미지 로테이션을 위한 이미지 인덱스 변수 선언
        Bitmap[] imagelist = { Properties.Resources.로고, Properties.Resources.Ad, Properties.Resources.Ad2}; // 비트맵 배열을 통해, imagelist에 이미지들을 저장, 프로퍼티 리소스에 있는 이미지들로 초기화
        User user; // User의 객체를 선언
        bool moderator = false; // 관리자인지 유저인지 확인하는 멤버 변수로 기본값을 false로 설정
        GroupBox[] groupboxObj; // 그룹 박스 컨트롤 배열을 생성
        Button[] buttons; // 버튼 컨트롤 배열을 생성
        Label[] label; // 라벨 컨트롤 배열을 생성
        // [ 첫 실행 ]
        // 폼 생성자
        public formUShome(User us, bool moderator)
        {
            InitializeComponent(); // 컨트롤을 배치
            user = us; // 로그인에서 로그인 정보를 담고있는 객체 us를 받아서 홈 폼에서 user에 참조 대입
            this.moderator = moderator; // 관리자일 경우, moderator에 true가 되고 일반 유저면 false 처리됨
            if (moderator == false) // 관리자 권한이 false일 경우
            {
                this.btnModifyCategory.Hide(); // 카테고리 수정 버튼을 숨김
            }
            else // 관리자 권한이 있을 경우
            {
                this.btnModifyCategory.Show(); // 카테고리 수정 버튼을 보임
                this.btnModify.Hide(); // 정보 수정 버튼 숨김
                this.btnAccount.Hide(); // 계좌 버튼 숨김
                this.btnCheckAuction.Hide(); // 현재 진행중 경매 조회 버튼을 숨김
                this.btnMyAuction.Hide(); // 내 경매 조회 버튼을 숨김
            }
        }
        // 폼이 로드 될떄 실행되는 함수
        private void formUShome_Load(object sender, EventArgs e)
        {
            RefreshInfromation(); // 유저 정보 갱신 함수
            RefreshCategory(); // 카테고리 갱신 함수(최초 1회만 실행)
            this.ActiveControl = cbboxCategory; // 카테고리 콤보 박스에 집중
            cbboxCategory.SelectedIndex = 0; // 카테고리 콤보 박스의 선택 값을 0으로 설정(이때 콤보박스 값 변화 이벤트가 실행되기 때문에 RefreshHomeobj 메소드를 실행하지 않아도 됨)
            timerRefresh.Tick += timerRefresh_Tick; // 새로고침 타이머 컴포넌트의 Tick 델리게이트에 timerRefresh_Tick 함수를 추가
            timerRefresh.Start(); // 타이머 시작
        }

        // [ 버튼 및 구현 ]
        // '정보 수정' 버튼 구현부
        private void btnModify_Click(object sender, EventArgs e)
        {
            Form _frm = new formPasswordCheck(user); // formPasswordCheck 폼에 user 객체를 보내는 형식
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }
        // '계좌' 버튼 구현부
        private void btnAccount_Click(object sender, EventArgs e)
        {
            Form _frm = new formUScash(user); // formUScash 폼에 user 객체를 보내는 형식
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }
        // '경매 등록' 버튼 구현부
        private void btnNewAuction_Click(object sender, EventArgs e)
        {
            Form _frm = new formUpload(user); // formUpload 폼에 user 객체를 보내기
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }
        // 카테고리 '수정' 버튼 구현부 
        private void btnModifyCategory_Click(object sender, EventArgs e)
        {
            Form _frm = new formEditCategory(); // formEditCategory() 폼에 user 객체를 보내기
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }
        // '매물' 버튼 구현부
        private void OpenAuction(object sender, EventArgs e)
        {
            Button btn = sender as Button; // Button 클래스의 객체를 만들어서 object sender 를 Button으로 바꿀 수 있다면 바꿈으로써 sneder에 들어오는 객체를 btn에 복사
            Form formAuctionobj = new formAuctionobj(btn.Name, moderator, user); // formAuctionobj 폼에 버튼의 이름, 관리자 권한, 유저 정보 객체를 넘김
            formAuctionobj.ShowDialog(); // _frm 폼을 단독 열기
        }
        // 카테고리 콤보박스의 선택 인덱스가 바뀌었을 경우
        private void cbboxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHomeObj(); // 폼의 매물 부분을 새로 고침(카테고리에 맞는 물건들만 보여주기 + 로고 이미지 변경)
        }
        // '새로고침' 버튼 구현부
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshInfromation(); // 폼에서 개인 정보 부분을 새로 고침
            RefreshHome(); // 폼에서 매물 부분을 새로 고침(카테고리에 맞는 물건들만 보여주기 + 로고 이미지 변경)
        }
        // '경매 입찰 확인' 버튼 구현부
        private void btnCheckAuction_Click(object sender, EventArgs e)
        {
            Form _frm = new formAuctioning(user); // formAuctioning() 폼에 user 객체를 보내기
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }
        // '내 경매글 관리' 버튼 구현부
        private void btnMyAuction_Click(object sender, EventArgs e)
        {
            Form _frm = new formMyAuction(user); // formMyAuction() 폼에 user 객체를 보내기
            _frm.ShowDialog(); // _frm 폼을 단독 열기
        }


        // [ 실시간 갱신 ]
        // 타이머 이벤트에 대입할 함수, interval = 15000(15초) 주기 간격 실행
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshHome(); // 폼의 홈 부분을 새로 고침
            RefreshInfromation(); // 폼의 개인 정보 부분을 새로 고침
        }
        // 홈(경매 물품)부분을 갱신하는 함수 + 로고 이미지 바뀌는 구현부
        private void RefreshHome()
        {
            pictureBoxLogo.BackgroundImage = imagelist[imageIndex++%imagelist.Count()]; // 픽처박스 로고 부분의 배경 이미지를 이미지리스트 배열의 인덱스에 맞는 이미지를 출력, imageindex는 0부터 시작해서 새로고침 할때마다 1씩 증가하고 imagelist.Count()를 통해서 해당 배열에 원소 개수가 몇개인지 확인, 나머지 연산자로 인해서 원소 개수의 범위 안에서 반복하게 됨.
            RefreshHomeObj(); // 홈의 매물 부분을 새로고침
        }
        // 홈(경매 물품) 갱신 함수
        private void RefreshHomeObj()
        {
            CheckCategory(); // 카테고리를 확인하여 카테고리 박스 안에 있는 텍스트가 카테고리 아이템에 존재하는지를 확인
            flowLayoutPanelHome.Controls.Clear(); // flowLayoutPanelHome에 있는 모든 컨트롤들을 삭제
            flowLayoutPanelHome.Controls.Add(labelIsObj); // labellsObj(경매 물품이 없다는 라벨)을 추가
            if (cbboxCategory.Text != "전체") // 콤보박스에서 선택한 카테고리가 전체가 아닐경우
            {
                RefreshHomeCategory(cbboxCategory.Text); // 메소드 중복을 통해서 카테고리에 맞는 목록들만 불러옴
            }
            else // 전체일 경우
            {
                RefreshHomeCategory(); // 메소드 중복을 통해서 모든 카테고리의 목록을 불러옴
            }
        }
        // 카테고리 콤보박스를 통해 카테고리에 존재하는 아이템인지 확인하는 함수
        private void CheckCategory()
        {
            if (!cbboxCategory.Items.Contains(cbboxCategory.Text)) // 만약 카테고리 박스 안의 아이템에 cbboxCategory의 텍스트 박스 안의 문자열 값이 없다면
            {
                if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) // 카테고리 안에 존재하지 않기에 해당 메세지 박스를 출력 OK버튼을 누를시 실행
                {
                    cbboxCategory.SelectedIndex = 0; // 콤보박스의 제일 첫 값을 선택
                }
            }
        }
        // 카테고리 MySqlDB로부터 동적버튼 + 홈 매물 정보를 받아오는 함수(카테고리 전체)
        private void RefreshHomeCategory()
        {
            int count = 0; // 몇개의 버튼을 만들건지 확인하는 변수 int count
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * FROM object WHERE ISLIVE = '{0}'", 0); // 쿼리문 작성, 현재 경매중인 물건을 카테고리 상관없이 다 받아옴
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MySql 쿼리문으로 객체화
                MySqlDataAdapter _da = new MySqlDataAdapter(_command); // 한번에 데이터를 받아와서 연결을 끊는 DataAdapter 형식을 사용
                DataTable _dt = new DataTable(); // 데이터 테이블 _dt를 생성
                _da.Fill(_dt); // _dt에 _da의 데이터들을 전부 복사하여 하나의 테이블을 형성
                DataRow[] EndAuction = _dt.Select("END_AUCTION <= '" + DateTime.Now + "'"); // 데이터의 열에서 END_AUCTION의 열 값들이 현재보다 작거나 같은 경우 마감 처리를 해야하기 때문에
                foreach (DataRow UpdateEnd in EndAuction) // 하나의 열을 선택할 UpdateEnd를 EndAuction에 마감될 열들만큼 반복
                {
                    string _NO = UpdateEnd["NO"].ToString(); // 마감될 열의 게시글 번호를 문자열로 받아와서 문자열 _NO에 저장
                    string _query2 = string.Format("UPDATE object SET ISLIVE = '1' WHERE NO = '{0}';", _NO); // 쿼리2로 해당 번호의 게시글을 마감
                    if (UpdateEnd["HIGHER_USER"].ToString() != string.Empty) // 만약 마감되는 경매물건의 최고 입찰자가 있을 경우
                    {
                        string _highestPrice = UpdateEnd["HIGHER_MONEY"].ToString(); // 최고 입찰 금액을 문자열로 변환
                        string _Uploader = UpdateEnd["UPLOAD_USER"].ToString(); // 업로더의 아이디를 문자열로 변환
                        string _highestUser = UpdateEnd["HIGHER_USER"].ToString(); // 최고 입찰자의 아이디를 문자열로 변환
                        _query2 += string.Format("UPDATE user SET MONEY = MONEY + {0} WHERE ID = '{1}';", _highestPrice, _Uploader); // 업데이트 쿼리문을 추가, 판매가 완료 되었으므로 업로더의 돈을 최고가만큼 추가시킴
                        _query2 += string.Format("UPDATE user SET COUNT_SUC_AUCTION = COUNT_SUC_AUCTION + 1 WHERE ID = '{0}';", _highestUser); // 최고 입찰자의 낙찰 받은 횟수를 1 증가
                        _command = new MySqlCommand(_query2, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB 쿼리문으로 객체 생성
                        _command.ExecuteNonQuery(); // 쿼리문 실행(정상적으로 됐을 경우 업데이트가 됨)
                    }
                    else // 입찰자가 없을 경우
                    {
                        _command = new MySqlCommand(_query2, MYSQL.mysql); // 게시글을 마감만 시켜주는 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문으로 객체화
                        _command.ExecuteNonQuery(); // 쿼리문을 실행(정상적으로 됐을 경우 업데이트가 됨(마감))
                    }
                }

                _query = string.Format("SELECT COUNT(*) FROM object WHERE ISLIVE = '{0}'", 0); // 마감하고 난 후의 경매중인 물건을 다시 받아옴. COUNT(*)를 통해서 경매중인 행이 몇개인지 확인하는 쿼리문
                _command = new MySqlCommand(_query, MYSQL.mysql); // 개수 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문으로 객체화 시키고
                count = Convert.ToInt32(_command.ExecuteScalar()); // 해당 명령어가 영향을 가는 행의 개수를 받아옴(정수형)
                if (count == 0) // 만약 영향가는 행이 없으면(즉, 경매중인 매물이 없다면)
                {
                    labelIsObj.Visible = true; // 경매 매물이 없다는 라벨을 보이게 설정하고
                    MYSQL.mysql.Close(); // MYSQL.mysql의 연결을 해제
                    return; // 함수를 종료
                }
                // 경매중인 매물이 있다면
                _query = string.Format("SELECT * FROM object WHERE ISLIVE = '{0}'", 0); // 쿼리문을 작성, 경매중인 매물들을 받아오기 위한 쿼리문
                _command = new MySqlCommand(_query, MYSQL.mysql); // 해당 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문으로 객체화 시키고
                MySqlDataReader _rdr = _command.ExecuteReader(); // _rdr에 데이터를 받아옴

                labelIsObj.Visible = false; // 경매 매물이 없다는 라벨을 보이지 않게 설정하고
                groupboxObj = new GroupBox[count]; // groupboxObj의 배열에 개수만큼 그룹 박스를 할당
                buttons = new Button[count]; // buttons의 배열에 개수만큼 버튼을 할당
                label = new Label[count]; // label의 배열에 개수만큼 라벨을 할당
                for (int i = 0; i < count; i++) // 0부터 개수까지 반복
                {
                    _rdr.Read(); // _rdr의 한 행을 읽고
                    TimeSpan LeftTime = Convert.ToDateTime(_rdr["END_AUCTION"]) - DateTime.Now; // LeftTime으로 남은 시간 객체 생성, 마감 일자에서 현재 시간을 뺀 시간을 LeftTime에 저장
                    label[i] = new Label(); // label 배열의 i번째에 Label 객체를 생성
                    label[i].Location = new System.Drawing.Point(7, 151); // 라벨의 위치를 7,151에 설정
                    label[i].Text = string.Format("제품명 : {0}", _rdr["NAME"].ToString()) + "\n\n" + string.Format("최고가 : {0:#,##0}", _rdr["HIGHER_MONEY"]) + "\n\n" + string.Format("남은 시간 : {0}일 {1}시간 {2}분", LeftTime.Days, LeftTime.Hours, LeftTime.Minutes); // 라벨의 텍스트를 생성, 남은 시간 객체의 남은 일자, 남은 시간, 남은 분을 각각 문자열 포맷에 맞게 대입
                    label[i].AutoSize = false; // 라벨의 자동 크기를 끔
                    label[i].Size = new System.Drawing.Size(170, 90); // 라벨의 크기를 가로: 170, 세로: 90으로 설정

                    buttons[i] = new Button(); // 버튼 i번째에 Button 객체를 생성
                    buttons[i].Location = new System.Drawing.Point(7, 10); // 버튼의 위치를 7,10으로 설정
                    buttons[i].Size = new System.Drawing.Size(170, 140); ; // 버튼의 크기를 가로: 170, 세로: 140으로 설정
                    buttons[i].Text = string.Empty; // 버튼의 텍스트를 공백으로 설정
                    buttons[i].BackgroundImageLayout = ImageLayout.Stretch; // 버튼의 배경 이미지 모를 Stretch모드로 버튼 안에서 꽉 차는 모드로 설정
                    buttons[i].Click += OpenAuction; // 버튼의 클릭 이벤트에 OpenAuction 함수를 추가
                    buttons[i].Name = _rdr["NO"].ToString(); // 버튼의 이름을 _rdr의 NO열의 문자열화 시킨 문자열로 설정
                    byte[] bt = null; // 바이트 배열 bt를 선언하고 null로 초기화
                    bt = (byte[])(_rdr["MAIN_PIC"]); // 바이트 배열 bt에 _rdr의 MAIN_PIC에 저장된 이미지 바이트 배열을 받아옴
                    MemoryStream mstream = new MemoryStream(bt); // 바이트 배열 bt를 메모리 스트림으로 연결
                    buttons[i].BackgroundImage = Image.FromStream(mstream); // 메모리 스트림 mstream을 이미지화 시켜서 버튼의 배경 이미지로 설정
                    mstream.Close(); // 메모리 스트림 연결 해제

                    groupboxObj[i] = new GroupBox(); // groupboxObj의 i번째에 그룹 박스 객체를 생성
                    groupboxObj[i].AutoSize = true; // 그룹 박스 자동 크기를 켬
                    groupboxObj[i].Location = new System.Drawing.Point(0, 0); // 그룹 박스의 위치를 0,0으로 설정
                    groupboxObj[i].Size = new System.Drawing.Size(172, 190); // 그룹 박스의 크기를 가로:172, 세로: 190로 설정
                    groupboxObj[i].TabStop = false; // 탭 키로 이동할 수 없도록 설정
                    groupboxObj[i].Controls.Add(buttons[i]); // 그룹 박스 안에 버튼을 추가
                    groupboxObj[i].Controls.Add(label[i]); // 그룹 박스 안에 라벨을 추가
                    if (LeftTime.TotalMinutes <= 30) // 만약 남은 시간의 총 분이 30분 이하일 경우
                    {
                        label[i].ForeColor = System.Drawing.Color.Red; // 라벨 글씨 색깔을 빨간색으로 설정
                    }
                    this.flowLayoutPanelHome.Controls.Add(groupboxObj[i]); // 플로우 레이아웃 패널에 그룹 박스를 추가하여 자동 정렬
                }
                _rdr.Close(); // _rdr 연결 해제
            }
            catch (Exception ex) // 예외처리가 발생시
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용은 예외처리 내용, 창 이름, 버튼은 OK, 아이콘은 Error로 설정하고 출력
            }
            finally // try 또는 catch가 끝났을 경우
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
            }
        }
        // 콤보박스 선택 값에 따라 MySqlDB로부터 동적 버튼 + 홈 매물 정보를 받아오는 함수
        private void RefreshHomeCategory(string table)
        {
            int count = 0; // 매물 개수를 저장할 변수 count를 선언 후 0으로 초기화
            try
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * FROM object WHERE CATEGORY = '{0}' AND ISLIVE = '{1}'", table, 0); // table은 콤보박스 선택값으로 카테고리가 콤보박스의 선택 문자열이면서 경매중인 물건을 받아오는 쿼리문
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문으로 객체화
                MySqlDataAdapter _da = new MySqlDataAdapter(_command); // _command에 만들어진 쿼리문을 실행하고 DataAdapter를 이용하여 _da에 데이터를 한번에 받아오고 연결을 끊음.
                DataTable _dt = new DataTable(); // 데이터 테이블 _dt를 선언하고
                _da.Fill(_dt); // _da에서 받아온 데이터를 _dt에 복사
                DataRow[] EndAuction = _dt.Select("END_AUCTION <= '" + DateTime.Now + "'"); // _dt에서 받아진 조건(경매 마감 시간이 현재 시간보다 적거나 같을 경우)에 부합하는 행들을 배열로 받음
                foreach (DataRow UpdateEnd in EndAuction) // UpdateEnd 행을 EndAuction 배열 내부를 반복
                {
                    string _NO = UpdateEnd["NO"].ToString(); // UpdateEnd 행의 NO 열의 값을 문자열로 받아서 저장
                    string _query2 = string.Format("UPDATE object SET ISLIVE = '1' WHERE NO = '{0}';", _NO); // 쿼리문을 작성, 경매를 마감시키는 업데이트 구문
                    if (UpdateEnd["HIGHER_USER"].ToString() != string.Empty) // 만약 입찰자가 없을 경우
                    {
                        string _highestPrice = UpdateEnd["HIGHER_MONEY"].ToString(); // 최고 입찰 금액을 문자열로 변환
                        string _Uploader = UpdateEnd["UPLOAD_USER"].ToString(); // 업로더의 아이디를 문자열로 변환
                        string _highestUser = UpdateEnd["HIGHER_USER"].ToString(); // 최고 입찰자의 아이디를 문자열로 변환
                        _query2 += string.Format("UPDATE user SET MONEY = MONEY + {0} WHERE ID = '{1}';", _highestPrice, _Uploader); // 업데이트 쿼리문을 추가, 판매가 완료 되었으므로 업로더의 돈을 최고가만큼 추가시킴
                        _query2 += string.Format("UPDATE user SET COUNT_SUC_AUCTION = COUNT_SUC_AUCTION + 1 WHERE ID = '{0}';", _highestUser); // 최고 입찰자의 낙찰 받은 횟수를 1 증가
                        _command = new MySqlCommand(_query2, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB 쿼리문으로 객체 생성
                        _command.ExecuteNonQuery(); // 쿼리문 실행(정상적으로 됐을 경우 업데이트가 됨)
                    }
                    else // 입찰자가 없을 경우
                    {
                        _command = new MySqlCommand(_query2, MYSQL.mysql); // 게시글을 마감만 시켜주는 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문으로 객체화
                        _command.ExecuteNonQuery(); // 쿼리문을 실행(정상적으로 됐을 경우 업데이트가 됨(마감))
                    }
                }
                _query = string.Format("SELECT COUNT(*) FROM object WHERE CATEGORY = '{0}' AND ISLIVE = '{1}'", table, 0); // 쿼리문 작성, 카테고리가 콤보박스에서 선택된 값이고, 경매 진행중인 개수를 찾기 위한 쿼리문
                _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문 객체화를 하고
                count = Convert.ToInt32(_command.ExecuteScalar()); // _command 명령어를 실행하면서 해당 쿼리가 영향을 미치는 행의 개수를 int형으로 받아오고 count에 저장
                if (count == 0) // 만약 해당 카테고리의 매물 개수가 0일 경우
                {
                    labelIsObj.Visible = true; // 매물이 없음을 출력
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결을 해제
                    return; // 함수 종료
                }
                // 매물이 있을 경우
                _query = string.Format("SELECT * FROM object WHERE CATEGORY = '{0}' AND ISLIVE = '{1}'", table,0); // 쿼리문을 작성, 카테고리가 콤보박스에서 선택된 값이고, 경매 진행중인 행을 찾기 위한 쿼리문
                _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 쿼리문 객체화를 하고
                MySqlDataReader _rdr = _command.ExecuteReader(); // 명령어를 실행하여 _rdr에 데이터를 받아옴

                labelIsObj.Visible = false; // 매물이 없다는 라벨을 안보이게 설정
                groupboxObj = new GroupBox[count]; // 그룹 박스 배열에 동적으로 count 개수만큼 할당
                buttons = new Button[count]; // 버튼 배열에 동적으로 count 개수만큼 할당
                label = new Label[count]; // 라벨 배열에 동적으로 count 개수만큼 할당
                for (int i = 0; i < count; i++) // count 만큼 반복
                {
                    _rdr.Read(); // 한 행씩 읽기
                    TimeSpan LeftTime = Convert.ToDateTime(_rdr["END_AUCTION"]) - DateTime.Now; // LeftTime으로 남은 시간 객체 생성, 마감 일자에서 현재 시간을 뺀 시간을 LeftTime에 저장
                    label[i] = new Label(); // label 배열의 i번째에 Label 객체를 생성
                    label[i].Location = new System.Drawing.Point(7, 151); // 라벨의 위치를 7,151에 설정
                    label[i].Text = string.Format("제품명 : {0}", _rdr["NAME"].ToString()) + "\n\n" + string.Format("최고가 : {0:#,##0}", _rdr["HIGHER_MONEY"]) + "\n\n" + string.Format("남은 시간 : {0}일 {1}시간 {2}분", LeftTime.Days, LeftTime.Hours, LeftTime.Minutes); // 라벨의 텍스트를 생성, 남은 시간 객체의 남은 일자, 남은 시간, 남은 분을 각각 문자열 포맷에 맞게 대입
                    label[i].AutoSize = false; // 라벨의 자동 크기를 끔
                    label[i].Size = new System.Drawing.Size(170, 90); // 라벨의 크기를 가로: 170, 세로: 90으로 설정

                    buttons[i] = new Button(); // 버튼 i번째에 Button 객체를 생성
                    buttons[i].Location = new System.Drawing.Point(7, 10); // 버튼의 위치를 7,10으로 설정
                    buttons[i].Size = new System.Drawing.Size(170, 140); ; // 버튼의 크기를 가로: 170, 세로: 140으로 설정
                    buttons[i].Text = string.Empty; // 버튼의 텍스트를 공백으로 설정
                    buttons[i].BackgroundImageLayout = ImageLayout.Stretch; // 버튼의 배경 이미지 모를 Stretch모드로 버튼 안에서 꽉 차는 모드로 설정
                    buttons[i].Click += OpenAuction; // 버튼의 클릭 이벤트에 OpenAuction 함수를 추가
                    buttons[i].Name = _rdr["NO"].ToString(); // 버튼의 이름을 _rdr의 NO열의 문자열화 시킨 문자열로 설정
                    byte[] bt = null; // 바이트 배열 bt를 선언하고 null로 초기화
                    bt = (byte[])(_rdr["MAIN_PIC"]); // 바이트 배열 bt에 _rdr의 MAIN_PIC에 저장된 이미지 바이트 배열을 받아옴
                    MemoryStream mstream = new MemoryStream(bt); // 바이트 배열 bt를 메모리 스트림으로 연결
                    buttons[i].BackgroundImage = Image.FromStream(mstream); // 메모리 스트림 mstream을 이미지화 시켜서 버튼의 배경 이미지로 설정
                    mstream.Close(); // 메모리 스트림 연결 해제

                    groupboxObj[i] = new GroupBox(); // groupboxObj의 i번째에 그룹 박스 객체를 생성
                    groupboxObj[i].AutoSize = true; // 그룹 박스 자동 크기를 켬
                    groupboxObj[i].Location = new System.Drawing.Point(0, 0); // 그룹 박스의 위치를 0,0으로 설정
                    groupboxObj[i].Size = new System.Drawing.Size(172, 190); // 그룹 박스의 크기를 가로:172, 세로: 190로 설정
                    groupboxObj[i].TabStop = false; // 탭 키로 이동할 수 없도록 설정
                    groupboxObj[i].Controls.Add(buttons[i]); // 그룹 박스 안에 버튼을 추가
                    groupboxObj[i].Controls.Add(label[i]); // 그룹 박스 안에 라벨을 추가
                    if (LeftTime.TotalMinutes <= 30) // 만약 남은 시간의 총 분이 30분 이하일 경우
                    {
                        label[i].ForeColor = System.Drawing.Color.Red; // 라벨 글씨 색깔을 빨간색으로 설정
                    }
                    this.flowLayoutPanelHome.Controls.Add(groupboxObj[i]); // 플로우 레이아웃 패널에 그룹 박스를 추가하여 자동 정렬
                }
                _rdr.Close(); // _rdr 연결 해제
            }
            catch (Exception ex) // 예외처리가 발생시
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용은 예외처리 내용, 창 이름, 버튼은 OK, 아이콘은 Error로 설정하고 출력
            }
            finally // try 또는 catch가 끝났을 경우
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
            }

        }
        // 유저 정보 갱신 메소드
        private void RefreshInfromation()
        {
            string _query; // 쿼리문 선언
            MySqlCommand _command; // DB에 연결할 쿼리문 객체 선언
            MySqlDataReader _rdr; // 데이터를 불러올 _rdr 선언
            string mode = moderator ? "moderator" : "user"; // 문자열 mode에 관리자일 경우 moderator 테이블에서 갱신, 유저일 경우 user 테이블에서 갱신
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                _query = string.Format("SELECT * FROM {1} WHERE ID = '{0}'", user.Id, mode); // 쿼리문을 작성, 문자열 포맷에 맞게 mode에 맞는 테이블에서 유저 아이디가 위치한 행을 선택
                _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql 에 연결된 DB의 쿼리문으로 객체화
                _rdr = _command.ExecuteReader(); // 쿼리문을 실행하여 _rdr에 데이터를 받아옴
                _rdr.Read(); // 한 행을 읽고
                byte[] bimage = null; // 바이트 배열을 선언(프로필 이미지 저장할 바이트 배열)
                if (_rdr["PROFILE"].ToString() != string.Empty) // 만약 _rdr의 프로필 열에 값이 없을 경우
                {
                    bimage = (byte[])(_rdr["PROFILE"]); // 바이트 배열 bimage에 _rdr의 PROFILE열에 있는 바이트를 바이트 배열화 시켜서 저장
                    user.Profile = bimage; // 유저 프로필 프로퍼티에 bimage를 통해 대입
                    MemoryStream mstream = new MemoryStream(bimage); // 메모리 스트림 mstream에 bimage(바이트 배열)을 연결
                    pictureBoxProfile.Image = System.Drawing.Image.FromStream(mstream); // 메모리 스트림에 연결된 바이트 배열을 이미지화 시켜서 픽처박스(프로필)의 이미지로 설정
                    mstream.Close(); // 메모리 스트림 연결 해제
                }
                else // _rdr의 프로필 열에 값이 없을 경우
                {
                    pictureBoxProfile.Image = Properties.Resources.unknown; // 유저 프로필 사진을 프로퍼티 리소스에서 unknown 이미지를 설정
                }
                user.Nickname = _rdr["NICKNAME"].ToString(); // 유저 닉네임 프로퍼티에 _rdr의 NICKNAME 열의 값을 문자열로 변환 후 대입
                user.Name = _rdr["NAME"].ToString(); // 유저 이름 프로퍼티에 _rdr의 NAME 열의 값을 문자열로 변환 후 대입
                user.Email = _rdr["EMAIL"].ToString(); // 유저 이메일 프로퍼티에 _rdr의 EMAIL 열의 값을 문자열로 변환 후 대입
                user.PhNum = _rdr["PHONE_NUMBER"].ToString(); // 유저 전화번호 프로퍼티에 _rdr의 PHONE_NUMBER 열의 값을 문자열로 변환 후 대입
                user.Id = _rdr["ID"].ToString(); // 유저 아이디 프로퍼티에 _rdr의 ID 열의 값을 문자열로 변환 후 대입
                user.Password = _rdr["PASSWORD"].ToString(); // 유저 비밀번호 프로퍼티에 _rdr의 PASSWORD 열의 값을 문자열로 설정
                user.Birthday = _rdr["BR_DAY"].ToString(); // 유저 생일 프로퍼티에 _rdr의 BR_DAY 열의 값을 문자열로 변환 후 대입
                user.Gender = _rdr["GENDER"].ToString(); // 유저 성별 프로퍼티에 _rdr의 GENDER 열의 값을 문자열로 변환 후 대입
                user.Address = _rdr["ADDRESS"].ToString(); // 유저 주소 프로퍼티에 _rdr의 ADDRESS 열의 값을 문자열로 변환 후 대입
                user.CountInAuction = Convert.ToInt32(_rdr["COUNT_IN_AUCTION"]); // 유저 입찰 횟수 프로퍼티에 _rdr의 COUNT_IN_AUCTION 열의 값을 정수로 변환 후 대입
                user.CountSucAuction = Convert.ToInt32(_rdr["COUNT_SUC_AUCTION"]); // 유저 낙찰 횟수 프로퍼티에 _rdr의 COUNT_SUC_AUCTION 열의 값을 정수로 변환후 대입
                user.Money = Convert.ToUInt64(_rdr["MONEY"]); // 유저 돈 프로퍼티에 _rdr의 MONEY 열의 값을 ulong으로 변환후 대입
                _rdr.Close(); // _rdr의 연결을 해제

                _query = string.Format("SELECT * FROM object WHERE ISLIVE = '0' AND HIGHER_USER = '{0}'", user.Id); // 쿼리문을 작성, 현재 경매중이면서 최고 입찰자가 본인인 행을 받음
                _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql 에 연결된 DB의 쿼리문으로 객체화
                _rdr = _command.ExecuteReader(); // _rdr에 데이터를 받아옴
                int MyAuctioning = 0; // 본인이 최고 입찰자인 매물의 개수를 담을 변수
                ulong sum = 0; // 본인이 최고 입찰자인 매물의 최고 금액은 본인이 넣은 돈이기 때문에, 합 변수
                while (_rdr.Read()) // 한 행씩 읽음
                {
                    MyAuctioning++; // 개수를 1씩 증가
                    sum += Convert.ToUInt64(_rdr["HIGHER_MONEY"]); // sum에 _rdr의 HIGHER_MONEY열의 값을 ulong 형식으로 변환 후 더해줌
                }
                if(MyAuctioning == 0) // 만약 본인이 최고 입찰 매물 개수가 0개일 경우
                {
                    labelAuctioningMoney.Text = "0"; // 0 문자열을 입찰중 라벨의 텍스트로 대입
                    labelTotalMoeny.Text = string.Format("{0:#,##0}",user.Money); // 입찰중인 금액이 없으므로 총 금액을 본인 금액으로 설정하고 총 금액 라벨의 텍스트로 대입
                }
                else
                {
                    labelAuctioningMoney.Text = string.Format("{0:#,##0}", sum); // 입찰중 금액을 문자열 포맷에 맞게 설정하고 입찰중 라벨의 텍스트로 대입
                    labelTotalMoeny.Text = string.Format("{0:#,##0}", (ulong.Parse(labelAuctioningMoney.Text, NumberStyles.AllowThousands) + user.Money)); // 총 금액의 텍스트를 입찰중 금액의 숫자형, 유저 돈을 더한 값을 문자열로 바꿔서 대입 
                }
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "사용자 정보 갱신 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외 메세지, 창 이름, OK버튼, 에러 아이콘을 출력
            }
            finally // try, catch를 끝냈을 경우
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 끊어줌
            }

            labelNickname.Text = "닉네임 : " + user.Nickname; // 닉네임 라벨에 유저 닉네임을 대입
            labelId.Text = "아이디 : " + user.Id; // 아이디 라벨에 유저 아이디를 대입
            labelInAuction.Text = "입찰 횟수 : " + user.CountInAuction.ToString(); // 입찰 횟수 라벨에 유저 입찰 횟수를 문자열로 바꿔서 대입
            labelSuccessAuction.Text = "낙찰 횟수 : " + user.CountSucAuction.ToString(); // 낙찰 횟수 라벨에 유저 낙찰 횟수를 문자열로 바꿔서 대입
            labelLeftMoney.Text = string.Format("{0:#,##0}", user.Money); // 입찰 가능 금액에 유저의 돈을 문자열 포맷에 맞게 대입
        }
        // 카테고리 갱신
        private void RefreshCategory()
        {
            cbboxCategory.Items.Clear(); // 콤보 박스의 아이템을 클리어
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = "SELECT * FROM category"; // 쿼리문을 작성, 카테고리 테이블의 모든 행을 선택
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리를 MYSQL.mysql DB의 쿼리문으로 객체화
                MySqlDataReader _rdr = _command.ExecuteReader(); // 데이터 리더 _rdr을 선언하고 쿼리문을 실행했을때 나오는 행들을 데이터로 받아옴
                while (_rdr.Read()) // 한 행이 읽어질 경우 계속 반복
                {
                    cbboxCategory.Items.Add(_rdr["category"].ToString()); // 카테고리 콤보박스의 아이템에 _rdr의 category 열의 값을 문자열화 시키고 추가
                }
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "카테고리 갱신 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외 메세지를 출력하고, 창 이름, 버튼 OK, 아이콘 Error 의 메세지 박스를 출력
            }
            finally // try, catch가 끝났을 시
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와 연결을 해제
            }
        }

        // [ 폼 종료 ]
        // '종료' 버튼 구현부
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (this.moderator == false) // 만약 일반 유저가 홈을 열었을 경우
            {
                Form _frm = new formExitCheck(); // 종료 폼을 생성하고
                _frm.ShowDialog(); // 종료 폼을 단독 열기
                return; // 함수 종료
            }
            this.Close(); // 관리자일 경우 해당 창을 닫음.
        }
        // 폼 종료시 발생하는 함수
        private void formUShome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (moderator) // 관리자일 경우
            {
                timerRefresh.Stop(); // 유저 정보, 홈 갱신 타이머를 멈춤
                return;
            }
            timerRefresh.Stop(); // 유저 정보, 홈 갱신 타이머를 멈춤
            Application.Exit(); // 애플리케이션을 종료
        }

    }
}

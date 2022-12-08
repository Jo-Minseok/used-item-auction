using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formUpload : Form
    {
        User user; // 멤버 User의 객체 user를 선언
        
        bool[] check = { false, false, false, false, false, false}; // bool형 타입으로 체크 인덱서를 선언, 총 6개로 선언하고 전부 false값으로 초기화
        bool this[int index] // 인덱서 프로퍼티를 선언, bool 형
        {
            get // get일 경우
            {
                return check[index]; // check 배열의 인덱스 값을 반환
            }
            set // set일 경우
            {
                check[index] = value; // check 배열의 인덱스에 bool형 값을 대입
            }
        }

        // [ 첫 실행 ]
        // 폼 생성자
        public formUpload(User us) // 유저 객체를 인자로 받음
        {
            user = us; // 멤버 유저 객체에 홈으로부터 받아온 us 객체를 참조 대입
            InitializeComponent(); // 컨트롤을 배치
        }
        // 폼 로드시 실행
        private void formUpload_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnUploadProfile; // 컨트롤 포커스를 메인 사진 '업로드' 버튼으로 설정
            dateTimeBuy.MaxDate = DateTime.Now; // 구매 날짜의 최대 날짜를 오늘로 설정
            dateTimeEnd.MinDate = DateTime.Now; // '경매 종료 날짜'의 최소 일을 오늘로 설정
            dateTimeEnd.MaxDate = DateTime.Now.AddDays(7); // '경매 마감 날짜'의 최대 일을 오늘 기준 +7 일까지로 설정
            dateTimePickerEndTime.CustomFormat = "tt hh:mm"; // '경매 종료 날짜'의 포맷을 오전or오후 시간:분으로 설정
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = "SELECT * FROM category"; // 쿼리문을 작성, 카테고리의 모든 행을 선택
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql와 연결된 DB의 쿼리문으로 객체화
                MySqlDataReader _rdr = _command.ExecuteReader(); // 쿼리문을 실행하여 데이터를 _rdr에 받아옴
                while (_rdr.Read()) // _rdr.Read()를 통해 한 행씩 받아옴
                {
                    if (_rdr["category"].ToString() == "전체") // 만약 _rdr의 category 열의 값이 "전체"일 경우
                    {
                        continue; // 계속 진행
                    }
                    cbboxCategory.Items.Add(_rdr["category"].ToString()); // 콤보박스에 아이템을 추가함. _rdr의 category 열의 값을 추가
                }
                _rdr.Close(); // _rdr의 연결을 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "경매 업로드 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력하고 예외 메세지, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch 문 이후 
            {
                MYSQL.mysql.Close(); // MYSQL.mysql와 연결된 DB와의 연결을 해제
            }
        }

        // [ 버튼 및 기능 구현 ]
        // '경매 등록' 버튼 구현부
        private void btnUploadobj_Click(object sender, EventArgs e)
        {
            if(dateTimeEnd.Value.Date + dateTimePickerEndTime.Value.TimeOfDay < DateTime.Now) // 만약 '경매 종료 날짜'의 날과 경매 종료 날짜의 시간부분의 시간을 더했을때 현재 날, 시간보다 과거라면
            {
                MessageBox.Show("경매 마감 시간은 현재 시간 이후여야 합니다.","경매 업로드 오류",MessageBoxButtons.OK,MessageBoxIcon.Error); // 메세지 박스를 출력, 내용, 창 이름, OK 버튼, Error 아이콘을 출력
                return; // 메소드 종료
            }
            if (cbboxCategory.Items.Contains(cbboxCategory.Text) == false) // 카테고리 콤보박스의 아이템에 콤보박스의 텍스트 문자열이 존재하지 않는다면
            {
                if (MessageBox.Show("해당 요소는 카테고리에 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { // 해당 메세지 박스를 출력, 내용, 창 이름 ,OK 버튼, 에러 아이콘을 출력하고 OK버튼을 누를 시에
                    cbboxCategory.SelectedIndex = 0; // 카테고리 콤보박스의 제일 첫 요소를 선택
                    return; // 메소드 종료
                }
            }
            if (MessageBox.Show("제품을 업로드 하시겠습니까?\n※주의사항!\n경매를 업로드 하고 나면 수정은 할 수 없습니다! 신중히 업로드 해주세요", "경매 업로드", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) // 메세지 박스를 출력, 내용, 창 이름, Yes or No 버튼, 경고 아이콘을 출력하고 Yes 버튼을 누를시
            {
                int count = 0; // 어느 칸이 올바르게 적혀있는지 개수를 세는 변수
                string _error = string.Empty; // 에러 문자열을 공백으로 설정
                for (int i = 0; i < 6; i++) // i가 0부터 5까지 총 6번을 돌면서 인덱서 값을 확인
                {
                    if (this[i] == true) // 만약에 i번째 인덱서가 true일 경우
                    {
                        count++; // count++로 올바른 개수를 1개 올림
                    }
                    else // false 일 경우
                    {
                        switch (i) // switch문을 통해서 어느 부분이 잘못되었는지 출력
                        {
                            case 0: // i가 0일 경우
                                _error += "카테고리를 선택하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                            case 1: // i가 1일 경우
                                _error += "제품 이름을 입력하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                            case 2: // i가 2일 경우
                                _error += "시작 금액을 입력하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                            case 3: // i가 3일 경우
                                _error += "구매 가격을 입력하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                            case 4: // i가 4일 경우
                                _error += "구매한 날짜를 입력하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                            case 5: // i가 5일 경우
                                _error += "설명을 입력하셔야 합니다.\n"; // 에러 문자열에 어디가 잘못 되었는지 추가
                                break; // switch문 탈출
                        }
                    }
                }
                if (count == 6) // 만약 카운트가 6이라면 모든 텍스트 박스가 올바르게 작성되었기 때문에
                {
                    try // 트라이문
                    {
                        string EndAuctionTime = dateTimeEnd.Value.Date.ToString("yyyy-MM-dd") + " " + dateTimePickerEndTime.Value.ToString("HH:mm"); // 문자열 경매 마감 날짜를 날짜 + 시간을 합친 형식으로 문자열을 생성
                        string BuyDate = dateTimeBuy.Value.Date.ToString("yyyy-MM-dd"); // 구매 날짜를 구매 데이트에서 값을 Date로 뽑아서 문자열 포맷에 맞게 문자열화
                        MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                        if (openMainImage.FileName != string.Empty) // 파일 경로가 빈 경로가 아니라면
                        {
                            string _queryCategory = "INSERT INTO object (CATEGORY, NAME, STARTMONEY, BUY_PRICE, BUY_DATE, UPLOAD_USER, END_AUCTION ,TEXT, HIGHER_MONEY, MAIN_PIC"; // 쿼리문 작성, 경매 매물 테이블에 해당 열들에 
                            string _queryValue = "VALUES ('" + cbboxCategory.SelectedItem + "', '" + txtboxObjname.Text + "', '" + ulong.Parse(txtboxStartmoney.Text,System.Globalization.NumberStyles.AllowThousands) + "', '" + ulong.Parse(txtboxBuyprice.Text, System.Globalization.NumberStyles.AllowThousands) + "', '" + BuyDate + "', '" + user.Id + "', '" + EndAuctionTime + "', '" + txtboxExplanation.Text + "', '" + ulong.Parse(txtboxStartmoney.Text, System.Globalization.NumberStyles.AllowThousands) + "', " + "@ParaMain"; // 해당 값들을 추가 @ParaMain은 메인 이미지 바이트 배열이 입력
                            byte[] MainBt = null; // MainBt 이미지 바이트 배열을 null로 초기화
                            byte[] Sub1Bt = null; // Sub1Bt 이미지 바이트 배열을 null로 초기화
                            byte[] Sub2Bt = null; // Sub2Bt 이미지 바이트 배열을 null로 초기화
                            byte[] Sub3Bt = null; // Sub3Bt 이미지 바이트 배열을 null로 초기화
                            FileStream Img = new FileStream(openMainImage.FileName, FileMode.Open, FileAccess.Read); // 파일 스트림 Img에 다이얼로그의 파일 경로에 위치한 파일을 열기 모드로, 읽기 접근자로 연결
                            BinaryReader br = new BinaryReader(Img); // 파일 스트림 Img에 연결되어 있는 파일을 바이너리 리더로 읽기
                            MainBt = br.ReadBytes((int)Img.Length); // MainBt(메인이미지 바이트 배열)에 바이너리 리더에서 바이트를 파일 스트림 길이만큼 읽어옴
                            Img.Close(); // 파일 스트림 연결 해제
                            br.Close(); // 바이너리 리더 연결 해제
                            if (openSubImage1.FileName != string.Empty) // 서브 이미지1 오픈 다이얼로그에서 선택된 파일이 있다면
                            {
                                Img = new FileStream(openSubImage1.FileName, FileMode.Open, FileAccess.Read); // Img 파일 스트림에 오픈한 파일 경로에 있는 파일을 열기 모드로 읽기 접근 지정자로 접근
                                br = new BinaryReader(Img); // Img 파일 스트림에서 바이너리 리더 
                                Sub1Bt = br.ReadBytes((int)Img.Length); // Sub1Bt = Img의 길이만큼 바이트를 읽어옴
                                Img.Close(); // 파일 스트림을 종료
                                br.Close(); // 바이너리 리더를 종료
                                _queryCategory += ", SUB_PIC1"; // 쿼리문 열에 SUB_PIC1을 추가
                                _queryValue += ", @ParaSub1"; // 쿼리문 값에 파라미터 @ParaSub1을 추가
                            }
                            if(openSubImage2.FileName != string.Empty) // 서브 이미지2 오픈 다이얼로그에서 선택된 파일이 있다면
                            {
                                Img = new FileStream(openSubImage2.FileName, FileMode.Open, FileAccess.Read); // Img 파일 스트림에 오픈한 파일 경로에 있는 파일을 열기 모드로 읽기 접근 지정자로 접근
                                br = new BinaryReader(Img); // Img 에 연결된 파일을 바이너리 리더로 읽어서 바이트 배열에 저장
                                Sub2Bt = br.ReadBytes((int)Img.Length); // 파일 스트림의 길이만큼 바이트 리더에서 바이트를 읽어서 Sub2Bt 바이트 배열에 저장
                                Img.Close(); // 파일 스트림을 종료
                                br.Close(); // 바이너리 리더를 종료
                                _queryCategory += ", SUB_PIC2"; // 쿼리문 열에 SUB_PIC2
                                _queryValue += ", @ParaSub2"; // 쿼리문 값에 파라미터 @ParaSub2을 추가
                            }
                            if(openSubImage3.FileName != string.Empty) // 서브 이미지3 오픈 다이얼로그에서 선택된 파일이 있다면
                            {
                                Img = new FileStream(openSubImage3.FileName, FileMode.Open, FileAccess.Read); // Img 파일 스트림에 오픈한 파일 경로에 있는 파일을 열기 모드로 읽기 접근 지정자로 접근
                                br = new BinaryReader(Img); // Img 파일 스트림으로부터 읽어온 파일을 바이너리 리더를 이용하여 br에 저장
                                Sub3Bt = br.ReadBytes((int)Img.Length); // 파일 스트림 길이만큼 바이너리 리더로부터 바이트 배열을 받아옴
                                Img.Close(); // 파일 스트림 연결을 해제
                                br.Close(); // 바이너리 리더 연결을 해제
                                _queryCategory += ", SUB_PIC3"; // 쿼리문의 열에 SUB_PIC3 값을 추가
                                _queryValue += ", @ParaSub3"; // 쿼리문의 값에 @ParaSub3 값을 추가
                            }
                            _queryCategory += ") "; // 쿼리문의 열을 마감처리
                            _queryValue += ")"; // 값의 열을 마감처리
                            string _query = _queryCategory + _queryValue; // 두 쿼리문을 합침으로써 하나의 쿼리문으로 형성
                            MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // 문자열 쿼리문을 실질적으로 MYSQL.mysql 에 연결된 DB에 사용할 수 있는 쿼리문으로 객체화한다.
                            _command.Parameters.Add(new MySqlParameter("@ParaMain", MainBt)); // 쿼리문의 파라미터에 MainBt 바이트 배열을 대입
                            if (openSubImage1.FileName != string.Empty) // 서브 이미지 1 파일 경로가 존재할 경우 
                            {
                                _command.Parameters.Add(new MySqlParameter("@ParaSub1", Sub1Bt)); // 파라미터에 Sub1Bt의 바이트 배열을 대입
                            }
                            if (openSubImage2.FileName != string.Empty) // 서브 이미지 2 파일 경로가 존재할 경우
                            {
                                _command.Parameters.Add(new MySqlParameter("@ParaSub2", Sub2Bt)); // 파라미터에 Sub2Bt의 바이트 배열을 대입
                            }
                            if (openSubImage3.FileName != string.Empty) // 서브 이미지 3 파일 경로가 존재할 경우
                            {
                                _command.Parameters.Add(new MySqlParameter("@ParaSub3", Sub3Bt)); // 파라미터에 Sub3Bt의 바이트 배열을 대입
                            }
                            _command.ExecuteNonQuery(); // 쿼리문 실행 (경매 등록 인서트 쿼리문)
                            MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
                            if (MessageBox.Show("제품 등록 완료!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK) // 메세지 박스를 출력, 내용, 창 이름, OK버튼, 아이콘(정보)를 출력, OK버튼을 눌렀을 경우
                            {
                                this.Close(); // 해당 폼 닫기
                            }
                            return; // 메소드 종료
                        }
                        MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
                        MessageBox.Show("제품 대표 이미지는 업로드를 하셔야합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 내용, 창 이름, OK버튼, 아이콘(에러)를 출력
                        this.pictureboxProfile.Focus(); // 메인 이미지 픽처박스에 포커스를 줌
                        return; // 메소드 종료
                    }
                    catch (Exception ex) // 예외 발생시
                    {
                        MessageBox.Show(ex.Message, "경매 업로드 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 예외처리되는 메세지를 출력, 창 이름, OK버튼, Error 아이콘을 출력
                    }
                    finally // try, catch 문을 끝내고 나서
                    {
                        MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
                    }
                }
                else // 텍스트 박스에 올바른 값이 하나라도 잘못되어있다면
                {
                    MessageBox.Show(_error, "경매 업로드 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 어느 부분이 비었고 잘못되었는지를 출력, 창 이름, OK버튼, 아이콘(에러)를 출력
                    this.txtboxObjname.Focus(); // 제품 이름 텍스트 박스에 포커스를 둠.
                }
            }
        }
        // 메인 이미지 '업로드' 버튼 구현부
        private void btnUploadProfile_Click(object sender, EventArgs e)
        {
            if (openMainImage.ShowDialog() == DialogResult.OK) // 만약 메인 이미지 다이얼로그에서 파일을 선택하여 확인 버튼을 눌렀을 경우
            {
                pictureboxProfile.ImageLocation = openMainImage.FileName; // 프로필 픽처박스 이미지 위치를 파일 선택했을때의 경로로 설정
            }
        }

        // 메인 사진 '삭제' 버튼 구현부
        private void btnMainRemove_Click(object sender, EventArgs e)
        {
            openMainImage.FileName = string.Empty;
            pictureboxProfile.Image = Properties.Resources.no;
        }

        // '제품 상세 이미지'의 서브 이미지1에서 '업로드1' 버튼 구현부
        private void btnUploadSub1_Click(object sender, EventArgs e)
        {
            if (openSubImage1.ShowDialog() == DialogResult.OK) // 만약 서브 이미지1 다이얼로그에서 파일을 선택하여 확인 버튼을 눌렀을 경우
            {
                btnSubImage1.BackgroundImage = new Bitmap(openSubImage1.FileName); // 버튼 서브 이미지1에서 백그라운드 이미지를 파일이 선택된 경로에서 비트맵 형식의 객체로 받아와서 바로 이미지로 대입
                groupboxSub2.Visible = true; // 서브 이미지2의 그룹 박스를 보이게 설정
            }
        }

        // '제품 상세 이미지'의 서브 이미지1에서 '+' 버튼 구현부
        private void btnSubImage1_Click(object sender, EventArgs e)
        {
            if (openSubImage1.ShowDialog() == DialogResult.OK) // 만약 서브 이미지1 다이얼로그에서 파일을 선택하여 확인 버튼을 눌렀을 경우
            {
                btnSubImage1.BackgroundImage = new Bitmap(openSubImage1.FileName); // 버튼 서브 이미지1에서 백그라운드 이미지를 파일이 선택된 경로에서 비트맵 형식의 객체로 받아와서 바로 이미지로 대입
                groupboxSub2.Visible = true; // 서브 이미지2의 그룹 박스를 보이게 설정
            }
        }

        // '제품 상세 이미지'의 서브 이미지1에서 '삭제' 버튼 구현부
        private void btnSubImg1Delete_Click(object sender, EventArgs e)
        {
            if (openSubImage2.FileName == string.Empty && openSubImage3.FileName == string.Empty) // 만약 서브 이미지 2 선택 파일이 존재하지 않으면서 서브 이미지 3 선택 파일이 존재하지 않으면
            {
                btnSubImage1.BackgroundImage = Properties.Resources.plus; // 서브 이미지1의 버튼 백그라운드 이미지를 프로퍼티.리소스.플러스 버튼으로 설정
                openSubImage1.FileName = string.Empty; // 서브 이미지 1의 파일 위치를 공백으로 설정
                groupboxSub3.Hide(); // 서브 이미지 그룹박스 3를 숨김
                groupboxSub2.Hide(); // 서브 이미지 그룹박스 2를 숨김
                return; // 메소드 종료
            }
            else // 위의 조건이 아닐 경우
            {
                if (openSubImage2.FileName != string.Empty && openSubImage3.FileName != string.Empty) // 서브이미지 2,3 있을 경우
                {
                    openSubImage1.FileName = openSubImage2.FileName; // 서브 이미지1의 파일 경로에 서브 이미지2의 파일 경로를 대입
                    btnSubImage1.BackgroundImage = new Bitmap(openSubImage1.FileName); // 버튼 1의 백그라운드 이미지를 서브 이미지1에 저장된 파일 경로(서브 이미지2의 파일 경로)에서 비트맵 형식으로 생성

                    openSubImage2.FileName = openSubImage3.FileName; // 서브 이미지2의 파일에 서브 이미지3의 파일을 대입
                    btnSubImage2.BackgroundImage = new Bitmap(openSubImage2.FileName); // 버튼 2의 백그라운드 이미지를 서브 이미지2에 저장된 파일 경로(서브 이미지3의 파일 경로)에서 비트맵 형식으로 생성
                    openSubImage3.FileName = string.Empty; // 서브 이미지3의 파일 위치에 공백을 대입
                    btnSubImage3.BackgroundImage = Properties.Resources.plus; // 버튼 3의 백그라운드 이미지를 '플러스' 버튼으로 설정
                    return; // 메소드 종료
                }
                else if (openSubImage2.FileName != string.Empty) // 서브이미지 2만 존재할 경우
                {
                    openSubImage1.FileName = openSubImage2.FileName; // 서브이미지 1의 파일 경로에 서브이미지 2의 파일 경로를 대입
                    btnSubImage1.BackgroundImage = new Bitmap(openSubImage1.FileName); // 서브이미지 1의 버튼 백그라운드 이미지를 서브 이미지1의 파일 경로를 비트맵 형식으로 변환하여 이미지로 대입
                    openSubImage2.FileName = string.Empty; // 서브 이미지 2의 파일 경로를 공백으로 설정
                    btnSubImage2.BackgroundImage = Properties.Resources.plus; // 서브 이미지2의 버튼 백그라운드 이미지를 프로퍼티스.리소스.플러스 버튼으로 설정
                    groupboxSub3.Hide(); // 서브이미지 그룹 3을 숨김
                    return; // 메소드 종료
                }
                else if (openSubImage3.FileName != string.Empty) // 서브 이미지 3만 존재할 경우
                {
                    openSubImage1.FileName = openSubImage3.FileName; // 서브이미지 3의 파일 경로를 서브이미지 1의 파일 경로에 대입
                    btnSubImage1.BackgroundImage = new Bitmap(openSubImage1.FileName); // 서브이미지1의 백그라운드 이미지를 서브이미지1의 파일 경로(서브이미지3의 파일 경로)에서 비트맵 형식으로 받아와서
                    openSubImage3.FileName = string.Empty; // 서브이미지3의 파일 경로를 공백으로 설정
                    groupboxSub3.Hide(); // 서브이미지 그룹 3을 숨김
                    return; // 메소드 종료
                }
            }
        }

        // '제품 상세 이미지'의 서브 이미지2에서 '업로드2' 버튼 구현부
        private void btnUploadSub2_Click(object sender, EventArgs e)
        {
            if (openSubImage2.ShowDialog() == DialogResult.OK) // 서브 이미지2의 오픈 다이얼로그에서 파일을 선택할 경우
            {
                btnSubImage2.BackgroundImage = new Bitmap(openSubImage2.FileName); // 서브 이미지2 버튼의 백그라운드 이미지에 서브 이미지2 파일 경로를 이미지화 시켜서 대입
                groupboxSub3.Visible = true; // 서브 이미지 그룹3을 보이게 함
            }
        }
        // '제품 상세 이미지'의 서브 이미지2에서 '플러스' 버튼 구현부
        private void btnSubImage2_Click(object sender, EventArgs e)
        {
            if (openSubImage2.ShowDialog() == DialogResult.OK) // 서브 이미지2의 오픈 다이얼로그에서 파일을 선택할 경우
            {
                btnSubImage2.BackgroundImage = new Bitmap(openSubImage2.FileName); // 서브 이미지2 버튼의 백그라운드 이미지에 서브 이미지2 파일 경로를 이미지화 시켜서 대입
                groupboxSub3.Visible = true; // 서브 이미지 그룹3을 보이게 함
            }
        }
        // '제품 상세 이미지'의 서브 이미지2에서 '삭제' 버튼 구현부
        private void btnSubImg2Delete_Click(object sender, EventArgs e)
        {
            if (openSubImage3.FileName == string.Empty) // 서브 이미지3 파일 경로가 비었을 경우
            {
                btnSubImage2.BackgroundImage = Properties.Resources.plus; // 서브 이미지2의 버튼 백그라운드 이미지를 프로퍼티스.리소스.플러스 버튼으로 설정
                openSubImage2.FileName = string.Empty; // 서브 이미지2 파일 경로를 공백으로 설정
                groupboxSub3.Hide(); // 서브 이미지 그룹3을 숨김
                return; // 메소드 종료
            }
            else
            {
                openSubImage2.FileName = openSubImage3.FileName; // 서브 이미지2의 경로에 서브 이미지3의 경로를 대입
                btnSubImage2.BackgroundImage = new Bitmap(openSubImage2.FileName); // 서브 이미지2의 경로를 이미지화 시켜서 서브 이미지2의 버튼 백그라운드 이미지로 설정
                openSubImage3.FileName = string.Empty; // 서브 이미지3의 파일 경로를 공백으로 설정
                btnSubImage3.BackgroundImage = Properties.Resources.plus; // 서브 이미지3 버튼의 백그라운드 이미지를 플러스로 설정
                return; // 메소드 종료
            }
        }

        // '제품 상세 이미지'의 서브 이미지3에서 '업로드3' 버튼 구현부
        private void btnUploadSub3_Click(object sender, EventArgs e)
        {
            if (openSubImage3.ShowDialog() == DialogResult.OK) // 서브 이미지3의 오픈 다이얼로그에서 파일을 선택할 경우
            {
                btnSubImage3.BackgroundImage = new Bitmap(openSubImage3.FileName); // 서브 이미지3 버튼의 백그라운드 이미지에 서브 이미지3 파일 경로를 이미지화 시켜서 대입
            }
        }
        // '제품 상세 이미지'의 서브 이미지3에서 '플러스' 버튼 구현부
        private void btnSubImage3_Click(object sender, EventArgs e)
        {
            if (openSubImage3.ShowDialog() == DialogResult.OK) // 서브 이미지3의 오픈 다이얼로그에서 파일을 선택할 경우
            {
                btnSubImage3.BackgroundImage = new Bitmap(openSubImage3.FileName); // 서브 이미지3 버튼의 백그라운드 이미지에 서브 이미지3 파일 경로를 이미지화 시켜서 대입
            }
        }
        // '제품 상세 이미지'의 서브 이미지3에서 '삭제' 버튼 구현부
        private void btnSubImg3Delete_Click(object sender, EventArgs e)
        {
            btnSubImage3.BackgroundImage = Properties.Resources.plus; // 서브 이미지3의 버튼 백그라운드 이미지를 플러스 이미지로 설정
            openSubImage3.FileName = string.Empty; // 서브 이미지3의 파일 경로를 공백으로 설정
        }

        // '설명' 텍스트 박스의 문자열 값이 바뀔 경우 발생하는 이벤트
        private void txtboxExplanation_TextChanged(object sender, EventArgs e)
        {
            if (txtboxExplanation.TextLength < 1000) // 설명 텍스트 박스의 텍스트 길이가 1000 미만일 경우
            {
                labelMaxString.ForeColor = System.Drawing.Color.DarkGray; // 설명 텍스트 현재 길이 및 최대 길이 라벨을 회색으로 설정
                labelMaxString.Text = string.Format("{0}/{1}", txtboxExplanation.TextLength, txtboxExplanation.MaxLength); // 최대 텍스트 라벨의 문자열을 스트링 포멧에 맞게 설정, 현재 텍스트 길이/최대 텍스트 길이
            }
            else // 1000일 경우
            {
                labelMaxString.ForeColor = System.Drawing.Color.Red; // 설명 텍스트 현재 길이 및 최대 길이 라벨을 빨강색으로 설정
                labelMaxString.Text = string.Format("{0}/{1}", txtboxExplanation.TextLength, txtboxExplanation.MaxLength); // 최대 텍스트 라벨의 문자열을 스트링 포멧에 맞게 설정, 현재 텍스트 길이/최대 텍스트 길이
            }
            if (dateTimeBuy.Value == DateTime.Now) // 만약 구매일자의 값이 현재의 값일경우
            {
                this[5] = false; // 인덱서 5번째의 값을 false로 설정
                return; // 메소드 종료
            }
            this[5] = true; // 인덱서 5번째의 값을 true로 설정
        }

        // 콤보박스 카테고리의 값이 바뀔 경우 발생하는 이벤트
        private void cbboxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this[0] = true; // 인덱서 0번째의 값을 true로 설정
        }

        // 경매 물건 이름 텍스트 박스의 텍스트가 바뀔 경우 발생하는 이벤트
        private void txtboxObjname_TextChanged(object sender, EventArgs e)
        {
            if (txtboxObjname.Text == string.Empty) // 만약 경매 물건 이름 텍스트가 없을 경우
            {
                this[1] = false; // 인덱서 1번째의 값을 false로 설정
                return; // 메소드 종료
            }
            this[1] = true; // 인덱서 1번째의 값을 true로 설정
        }

        // 경매물건의 시작 금액의 텍스트 박스 값이 바뀔경우 실행
        private void txtboxStartmoney_TextChanged(object sender, EventArgs e)
        {
            try // 트라이문
            {
                ulong text = ulong.Parse(txtboxStartmoney.Text, NumberStyles.AllowThousands); // 텍스트 박스의 텍스트에서 3자리마다 ,가 있는 수를 ,를 없애고 ulong text에 대입
                txtboxStartmoney.Text = string.Format("{0:#,##0}", text); // text를 3자리수마다 콤마로 설정
                txtboxStartmoney.SelectionStart = txtboxStartmoney.Text.Length; // 시작 금액의 텍스트 박스 시작 위치를 텍스트 박스의 텍스트 길이의 마지막 위치로 설정
            }
            catch (Exception) // 예외처리 발생시(텍스트 박스에 숫자가 없을 경우)
            {
                txtboxStartmoney.Text = "0"; // 시작 금액 텍스트 박스의 텍스트를 0으로 설정
                return; // 메소드 종료
            }
            if (txtboxStartmoney.Text == "0") // 시작 금액의 문자열이 0 일 경우
            {
                this[2] = false; // 인덱서의 2번째 값을 false로 설정
                return; // 메소드 종료
            }
            this[2] = true; // 인덱서의 2번째 값을 true로 설정
        }

        // 구매 금액 텍스트 박스의 값이 바뀌었을시
        private void txtboxBuyprice_TextChanged(object sender, EventArgs e)
        {
            try // 트라이문
            {
                ulong text = ulong.Parse(txtboxBuyprice.Text, NumberStyles.AllowThousands); // 구매 금액 텍스트 박스의 문자열을 3자리 ,콤마를 사라지게 만들어서 ulong형으로 대입
                txtboxBuyprice.Text = string.Format("{0:#,##0}", text); // 구매 금액 텍스트 박스의 문자열을 해당 포맷에 맞춰서 문자열로 형성
                txtboxBuyprice.SelectionStart = txtboxBuyprice.Text.Length; // 구매 금액 텍스트 박스의 시작 위치를 구매 금액 텍스트 박스의 텍스트 길이 즉, 마지막 위치로 시작
            }
            catch (Exception) // 예외처리 발생시(텍스트 박스에 숫자가 없을 경우)
            {
                txtboxBuyprice.Text = "0"; // 구매 금액 텍스트 박스의 문자열을 "0"으로 설정
                return; // 메소드 종료
            }
            if (txtboxStartmoney.Text == "0") // 구매 금액 텍스트 박스의 문자열이 0일 경우
            {
                this[3] = false; // 인덱서로 3번째 값을 false로 설정
                return; // 메소드 종료
            }
            this[3] = true; // 인덱서로 3번째 값을 true로 설정
        }

        // 구매 날짜의 달력 값이 바뀔 경우
        private void dateTimeBuy_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeBuy.Value == DateTime.Now) // 만약 구매 날짜의 달력값이 오늘일 경우
            {
                this[4] = false; // 인덱서 4번째 값을 false로 설정
                return; // 메소드 종료
            }
            this[4] = true; // 인덱서 4번째 값을 true로 설정
        }

        // 시작 금액 텍스트 박스 키프레스 이벤트
        private void txtboxStartmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 만약 숫자 또는 백스페이스 키가 아닐 경우
            {
                e.Handled = true; // 이벤트가 처리되었다고 설정하여 입력하지 않음
            }
        }

        // 구매 금액 텍스트 박스 키프레스 이벤트
        private void txtboxBuyprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 만약 숫자 또는 백스페이스 키가 아닐 경우
            {
                e.Handled = true; // 이벤트가 처리되었다고 설정하여 입력하지 않음
            }
        }
        // [ 폼 종료 ]
        // '취소' 버튼 구현부
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼을 닫음
        }
    }
}

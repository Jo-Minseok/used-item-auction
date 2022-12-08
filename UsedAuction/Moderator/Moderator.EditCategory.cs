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

namespace deal_Program
{
    public partial class formEditCategory : Form
    {
        string query; // 쿼리문 선언
        MySqlCommand command; // 실질적으로 DB에 입력될 쿼리를 만드는 객체
        MySqlDataReader rdr; // 데이터 리더 rdr을 선언
        // [ 첫 실행 ]
        // 폼 생성자
        public formEditCategory()
        {
            InitializeComponent(); // 컨트롤을 배치
        }
        // 폼을 로드 했을때 실행
        private void formEditCategory_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtboxAddcategory; // 폼에서 포커스 되는 곳을 카테고리 추가 텍스트 박스로 설정
            RefreshCategory(); // 카테고리를 갱신하는 메소드 호출
        }

        // [ 버튼 및 기능 구현 ]
        // '추가' 버튼 구현부
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                query = string.Format("INSERT INTO category (category) VALUES ('{0}')",txtboxAddcategory.Text); // 쿼리문을 작성, 문자열 포맷에 맞게 INSERT를 하는 쿼리문, category 테이블의 category의 값에 카테고리 추가 텍스트 박스의 값을 추가함
                command = new MySqlCommand(query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결되어 있는 DB의 쿼리 명령어로 객체화
                command.ExecuteNonQuery(); // 쿼리문을 실질적 실행
                cklistboxCategory.Items.Add(txtboxAddcategory.Text); // 체크 리스트의 아이템에 '추가 카테고리 텍스트 박스'에 있는 문자열을 추가
            }
            catch(Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "카테고리 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 예외 메세지를 출력하고, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch 실행 후
            {
                MYSQL.mysql.Close(); // MYSQL.mysql과 연결된 DB와 연결을 해제
            }
        }

        // '제거' 버튼 구현부
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                for (int i=cklistboxCategory.Items.Count -1; i>=0;i--) { // for문을 통해서 items의 개수-1부터 0까지 접근을 해야하기때문에 개수 -1을 하고 i>=0이 될때까지 i--를 진행
                    if(cklistboxCategory.GetItemChecked(i)) // 체크 리스트의 i번쨰 아이템이 체크 상태라면
                    {
                        query = string.Format("DELETE FROM category WHERE category = '{0}'", cklistboxCategory.Items[i]); // 카테고리 DB에서 체크된 카테고리를 삭제하는 쿼리문을 작성
                        command = new MySqlCommand(query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 실질적 쿼리문으로 만들기 위한 객체 command를 만들고
                        command.ExecuteNonQuery(); // 쿼리문을 실행
                        cklistboxCategory.Items.RemoveAt(i); // 체크 리스트의 i번쨰 아이템을 삭제
                    }
                }
            }
            catch(Exception ex) // 예외 발생시 실행
            {
                MessageBox.Show(ex.Message,"카테고리 수정 오류",MessageBoxButtons.OK,MessageBoxIcon.Error); // 메세지 박스를 출력, 예외처리의 메세지, 창 이름, 버튼 OK, 아이콘을 Error로 설정하여 출력
            }
            finally // try, catch가 끝났을때 실행
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제
            }
        }

        // '초기화' 버튼 구현부
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                query = string.Format("DELETE FROM category WHERE NO > '{0}'",1); // 쿼리문을 작성, '전체' 카테고리는 삭제를 하면 안되기 때문에, '전체' 카테고리를 제외하고 모두 삭제
                command = new MySqlCommand(query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 실질적 쿼리문으로 만들기 위한 객체 command를 만들고
                command.ExecuteNonQuery(); // 쿼리문을 실행
                cklistboxCategory.Items.Clear(); // 체크리스트의 모든 아이템을 초기화
                cklistboxCategory.Items.Add("전체"); // 체크리스트의 아이템에 '전체'를 추가
            }
            catch(Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "카테고리 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 내용, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch를 실행하고 나서
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제함
            }
        }

        // [ 갱신 ]
        // '새로고침' 버튼 구현부
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCategory(); // 카테고리를 갱신하는 메소드를 호출
        }

        // 카테고리를 갱신하는 메소드
        private void RefreshCategory()
        {
            try // 트라이문
            {
                cklistboxCategory.Items.Clear(); // 카테고리 콤보박스의 아이템을 클리어
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                query = "SELECT * FROM category"; // 쿼리문을 작성, 카테고리 테이블을 선택(모든 요소 선택)
                command = new MySqlCommand(query, MYSQL.mysql); // 쿼리문을 MYSQL.mysql에 연결된 DB의 실질적 쿼리문으로 만들기 위한 객체 command를 만들고
                rdr = command.ExecuteReader(); // rdr에 command를 실행했을때 나오는 데이터를 받아옴.
                while (rdr.Read()) // 처음부터 마지막까지 읽어서
                {
                    cklistboxCategory.Items.Add(rdr["category"]); // rdr의 category 열의 값을 체크 리스트에 추가
                }
                rdr.Close(); // rdr 연결 해제
            }
            catch (Exception ex) // 예외 발생시
            {
                MessageBox.Show(ex.Message, "카테고리 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스 출력, 예외처리 메세지, 창 이름, OK버튼, Error 아이콘 출력
            }
            finally // try, catch 실행하고 나서
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB를 연결 해제함
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

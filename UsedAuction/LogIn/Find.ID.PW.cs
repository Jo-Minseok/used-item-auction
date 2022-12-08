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
    public partial class formFindIP : Form
    {
        // [ 첫 실행 ]
        // 폼 생성자
        public formFindIP()
        {
            InitializeComponent(); // 컨트롤 배치
        }
        // 폼 로드시 실행
        private void formFindIP_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtboxName; // 컨트롤 집중 포커스를 이름 텍스트 박스로 설정
        }

        // [ 버튼 및 기능 구현 ]
        // 아이디 찾기 '검색' 버튼 구현부
        private void btnIdFind_Click(object sender, EventArgs e)
        {
            string mode = (checkboxModerator.Checked) ? "moderator" : "user"; // 문자열 mode에 '관리자 계정'이 체크되어 있을 경우 관리자 모드로 설정, 체크 안되어 있을 경우 일반 유저 모드로 설정
            if (txtboxName.Text == string.Empty || txtboxEmail.Text == string.Empty) // 이름 텍스트 박스와 이메일 텍스트 박스중 하나라도 빈칸일 경우
            {
                labelResultID.ForeColor = System.Drawing.Color.Red; // ID 결과 라벨의 글꼴 색을 빨강색으로 설정
                labelResultID.Text = "빈칸 없이 기재해주시길 바랍니다."; // ID 결과 라벨의 텍스트를 문자열로 설정
                return; // 메소드 종료
            }
            // 둘다 값이 있을 경우
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결되어 있는 DB를 오픈
                string _query = string.Format("SELECT * From {0} WHERE NAME = '{1}' AND EMAIL = '{2}'", mode, txtboxName.Text, txtboxEmail.Text); // 쿼리문을 작성, mode에 맞는 테이블로부터 이름, 이메일이 올바른 값을 찾는 쿼리문
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // MYSQL.mysql에 연결된 DB에 실질적으로 쿼리를 사용하기 위한 객체 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // 쿼리문을 실행하여 _rdr에 데이터를 읽음
                if (_rdr.Read()) // 만약 이메일과 이름이 있는 행이 있다면
                {
                    labelResultID.Text = string.Format("해당 정보의 아이디는 '{0}' 입니다.", _rdr["ID"].ToString()); // ID 찾기 결과 라벨에 문자열 포맷 형식을 대입 _rdr의 ID열에 있는 값을 문자열로 바꿔서 대입
                    labelResultID.ForeColor = System.Drawing.Color.Blue; // 결과 라벨의 글 색깔을 파란색으로 설정
                    _rdr.Close(); // _rdr의 연결을 해제
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
                    return; // 메소드 종료
                }
                // 이메일과 이름이 있는 행이 없다면
                _rdr.Close(); // _rdr의 연결을 해제
                labelResultID.Text = "해당 정보에 일치하는 회원이 존재하지 않습니다!"; // 아이디 찾기 결과 라벨의 텍스트를 문자열로 설정
                labelResultID.ForeColor = System.Drawing.Color.Red; // 라벨의 색깔을 빨강색으로 설정
            }
            catch(Exception ex) // 예외 발생시 실행
            {
                MessageBox.Show(ex.Message,"비밀번호 아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외처리 메세지, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch가 끝나면 실행
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB로부터 연결을 해제
            }
        }
        // '비밀번호 찾기'의 검색 버튼 구현부
        private void btnPwFind_Click(object sender, EventArgs e)
        {
            string mode = (checkboxModerator.Checked) ? "moderator" : "user"; // 문자열 mode에 '관리자 계정'이 체크되어 있을 경우 관리자 모드로 설정, 체크 안되어 있을 경우 일반 유저 모드로 설정
            if (txtboxId.Text == string.Empty || txtboxPh.Text == string.Empty) // 아이디 텍스트 박스와 이메일 전화번호 텍스트 박스중 하나라도 빈칸일 경우
            {
                labelResultPW.ForeColor = System.Drawing.Color.Red; // 비밀번호 결과 라벨의 글꼴 색을 빨강색으로 설정
                labelResultPW.Text = "빈칸 없이 기재해주시길 바랍니다."; // 비밀번호 결과 라벨의 텍스트를 문자열로 설정
                return; // 메소드 종료
            }
            try // 트라이문
            {
                MYSQL.mysql.Open(); // MYSQL.mysql에 연결된 DB를 오픈
                string _query = string.Format("SELECT * From {0} WHERE ID = '{1}' AND PHONE_NUMBER = '{2}'",mode, txtboxId.Text, txtboxPh.Text); // 쿼리문을 작성, 아이디와 전화번호에 적합한 데이터있다면 선택하는 쿼리문을 작성
                MySqlCommand _command = new MySqlCommand(_query, MYSQL.mysql); // MYSQL.mysql에 연결된 DB에 실질적으로 쿼리를 사용하기 위한 객체 생성
                MySqlDataReader _rdr = _command.ExecuteReader(); // 쿼리문을 실행하여 _rdr에 데이터를 읽음
                if (_rdr.Read()) // 만약 아이디와 전화번호가 있는 행이 있다면
                {
                    labelResultPW.Text = string.Format("해당 정보의 비밀번호는 '{0}' 입니다.", _rdr["PASSWORD"].ToString()); // 비밀번호 찾기 결과 라벨에 문자열 포맷 형식을 대입 _rdr의 PASSWORD열에 있는 값을 문자열로 바꿔서 대입
                    labelResultPW.ForeColor = System.Drawing.Color.Blue; // 결과 라벨의 글 색깔을 파란색으로 설정
                    _rdr.Close(); // _rdr의 연결을 해제
                    MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결을 해제
                    return; // 메소드 종료
                }
                // 아이디와 전화번호가 있는 행이 없다면
                _rdr.Close(); // _rdr의 연결을 해제
                labelResultPW.Text = "해당 정보에 일치하는 회원이 존재하지 않습니다!"; // 비밀번호 찾기 결과 라벨의 텍스트를 문자열로 설정
                labelResultPW.ForeColor = System.Drawing.Color.Red; // 결과 라벨의 글 색깔을 빨강색으로 설정
            }
            catch (Exception ex) // 예외 발생시 실행
            {
                MessageBox.Show(ex.Message, "비밀번호 아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); // 메세지 박스를 출력, 예외처리 메세지, 창 이름, OK 버튼, Error 아이콘을 출력
            }
            finally // try, catch 실행 후 실행하는 finally 구문
            {
                MYSQL.mysql.Close(); // MYSQL.mysql에 연결된 DB와의 연결 해제
            }
        }
        // [ 폼 종료 ]
        // '취소'버튼 구현부
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼 닫기
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formPasswordCheck : Form
    {
        User _user; // _user 객체 선언
        // [ 첫 실행 ]
        // 폼 생성자 실행
        public formPasswordCheck(User us)
        {
            InitializeComponent(); // 컴포넌트와 컨트롤을 생성
            _user = us; // _user객체에 홈에서부터 받아온 유저 객체를 대입
        }
        // 폼 로드시 실행
        private void formPasswordCheck_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtbxPW; // 포커스를 비밀번호 확인 텍스트 박스로 주기
        }
        // [ 버튼 및 기능 구현 ]
        // '확인' 버튼 구현
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtbxPW.Text != _user.Password) // 만약 비밀번호 텍스트 박스에 입력된 문자열과 유저의 비밀번호가 다르다면
            {
                MessageBox.Show("비밀번호가 틀립니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 비밀번호가 다르다는 메세지 박스를 출력
                return; // 함수 종료
            }
            Form _frm = new formUserModifyProfile(_user); // 폼 _frm을 생성하고 _user 객체를 넘겨줌
            _frm.ShowDialog(); // _frm을 집중 열기모드로 실행
            this.Hide(); // 비밀번호 확인 폼을 닫음
        }

        // [ 폼 종료 ]
        // '취소' 버튼 구현
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 비밀번호 확인 폼을 닫음
        }
    }
}

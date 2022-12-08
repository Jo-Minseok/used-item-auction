using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace deal_Program
{
    public partial class formExitCheck : Form
    {

        private int duration = 10; // 카운터를 10으로 설정
        // [ 첫 실행 ]
        // 폼 생성자
        public formExitCheck()
        {
            InitializeComponent(); // 컨트롤을 배치
        }

        // 폼을 로드 했을 경우
        private void formExitCheck_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnExitNo; // 폼이 집중하는 컨트롤을 '아니요' 버튼으로 설정
            timerExit.Tick += timer_Tick; // 나가기 타이머의 Tick 델리게이트에 timer_Tick을 추가
            timerExit.Start(); // 나가기 타이머를 실행
        }

        // [ 버튼 및 기능 구현 + 갱신 ]
        // 나가기 타이머 구현 (1초마다)
        private void timer_Tick(object sender, EventArgs e)
        {
            if(duration == 0) // 만약 카운터가 0일 경우
            {
                Application.Exit(); // 애플리케이션을 종료
            }
            duration--; // 아닐 경우 duration을 1씩 감소
            btnExitYes.Text = "예(" + duration + ")"; // '예'버튼의 텍스트를 해당 텍스트로 변경
        }
        // '아니요' 버튼 구현부
        private void btnExitNo_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼 닫기
        }

        // [ 폼 종료 ]
        // '예' 버튼 구현부
        private void btnExitYes_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 애플리케이션 종료
        }
        // 폼이 닫히면서 실행되는 메소드
        private void formExitCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerExit.Stop(); // 타이머를 스탑
        }
    }
}

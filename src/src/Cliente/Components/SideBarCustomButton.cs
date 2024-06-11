using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_ProjetoFinal.Components
{
    public partial class SideBarCustomButton : Button
    {
        //Propriedades
        private static SideBarCustomButton activeButton;
        private Image _NormalImage;
        private Image _HoverImage;
        private Color _HoverForeColor;
        private Color _NormalForeColor;
        private bool _IsActivated;

        public SideBarCustomButton()
        {
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            
            InitializeComponent();
        }

        [Category("Custom Properties")]
        public Image NormalImage { get => _NormalImage; set => _NormalImage = value; }

        [Category("Custom Properties")]
        public Image HoverImage { get => _HoverImage; set => _HoverImage = value; }

        [Category("Custom Properties")]
        public Color HoverForeColor { get => _HoverForeColor; set => _HoverForeColor = value; }

        [Category("Custom Properties")]
        public Color NormalForeColor { get => _NormalForeColor; set => _NormalForeColor = value; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void SideBarCustomButton_MouseEnter(object sender, EventArgs e)
        {
            Image = _HoverImage;
            ForeColor = _HoverForeColor;
        }

        private void SideBarCustomButton_MouseLeave(object sender, EventArgs e)
        {
            if (_IsActivated)
            {
                return;
            }
            Image = _NormalImage;
            ForeColor = _NormalForeColor;
        }

        private void SideBarCustomButton_Click(object sender, EventArgs e)
        {
            if (activeButton != null && activeButton != this)
            {
                activeButton._IsActivated = false;
                activeButton.Image = activeButton._NormalImage;
                activeButton.ForeColor = activeButton._NormalForeColor;
            }

            _IsActivated = true;
            Image = _HoverImage;
            ForeColor = _HoverForeColor;
            activeButton = this;
        }

        public bool GetState()
        {
            return _IsActivated;
        }

    }
}

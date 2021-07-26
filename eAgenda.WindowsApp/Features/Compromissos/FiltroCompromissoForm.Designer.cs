
namespace eAgenda.WindowsApp.Features.Compromissos
{
    partial class FiltroCompromissoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdbCompromissosPassados = new System.Windows.Forms.RadioButton();
            this.rdbCompromissosFuturos = new System.Windows.Forms.RadioButton();
            this.rdbTodosCompromissos = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.rdbProximoMes = new System.Windows.Forms.RadioButton();
            this.rdbProximaSemana = new System.Windows.Forms.RadioButton();
            this.rdbProxima24Horas = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbCompromissosPassados
            // 
            this.rdbCompromissosPassados.AutoSize = true;
            this.rdbCompromissosPassados.Location = new System.Drawing.Point(28, 112);
            this.rdbCompromissosPassados.Margin = new System.Windows.Forms.Padding(4);
            this.rdbCompromissosPassados.Name = "rdbCompromissosPassados";
            this.rdbCompromissosPassados.Size = new System.Drawing.Size(309, 21);
            this.rdbCompromissosPassados.TabIndex = 11;
            this.rdbCompromissosPassados.TabStop = true;
            this.rdbCompromissosPassados.Text = "Visualizar somente Compromissos passados";
            this.rdbCompromissosPassados.UseVisualStyleBackColor = true;
            // 
            // rdbCompromissosFuturos
            // 
            this.rdbCompromissosFuturos.AutoSize = true;
            this.rdbCompromissosFuturos.Location = new System.Drawing.Point(28, 71);
            this.rdbCompromissosFuturos.Margin = new System.Windows.Forms.Padding(4);
            this.rdbCompromissosFuturos.Name = "rdbCompromissosFuturos";
            this.rdbCompromissosFuturos.Size = new System.Drawing.Size(296, 21);
            this.rdbCompromissosFuturos.TabIndex = 10;
            this.rdbCompromissosFuturos.TabStop = true;
            this.rdbCompromissosFuturos.Text = "Visualizar somente Compromissos Futuros";
            this.rdbCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // rdbTodosCompromissos
            // 
            this.rdbTodosCompromissos.AutoSize = true;
            this.rdbTodosCompromissos.Location = new System.Drawing.Point(28, 29);
            this.rdbTodosCompromissos.Margin = new System.Windows.Forms.Padding(4);
            this.rdbTodosCompromissos.Name = "rdbTodosCompromissos";
            this.rdbTodosCompromissos.Size = new System.Drawing.Size(244, 21);
            this.rdbTodosCompromissos.TabIndex = 9;
            this.rdbTodosCompromissos.TabStop = true;
            this.rdbTodosCompromissos.Text = "Visualizar todos os Compromissos";
            this.rdbTodosCompromissos.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(362, 275);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(254, 275);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 28);
            this.btnGravar.TabIndex = 7;
            this.btnGravar.Text = "Filtrar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // rdbProximoMes
            // 
            this.rdbProximoMes.AutoSize = true;
            this.rdbProximoMes.Location = new System.Drawing.Point(28, 150);
            this.rdbProximoMes.Margin = new System.Windows.Forms.Padding(4);
            this.rdbProximoMes.Name = "rdbProximoMes";
            this.rdbProximoMes.Size = new System.Drawing.Size(269, 21);
            this.rdbProximoMes.TabIndex = 12;
            this.rdbProximoMes.TabStop = true;
            this.rdbProximoMes.Text = "Visualizar Compromissos próximo mês";
            this.rdbProximoMes.UseVisualStyleBackColor = true;
            // 
            // rdbProximaSemana
            // 
            this.rdbProximaSemana.AutoSize = true;
            this.rdbProximaSemana.Location = new System.Drawing.Point(28, 189);
            this.rdbProximaSemana.Margin = new System.Windows.Forms.Padding(4);
            this.rdbProximaSemana.Name = "rdbProximaSemana";
            this.rdbProximaSemana.Size = new System.Drawing.Size(295, 21);
            this.rdbProximaSemana.TabIndex = 13;
            this.rdbProximaSemana.TabStop = true;
            this.rdbProximaSemana.Text = "Visualizar Compromissos próxima Semana";
            this.rdbProximaSemana.UseVisualStyleBackColor = true;
            // 
            // rdbProxima24Horas
            // 
            this.rdbProxima24Horas.AutoSize = true;
            this.rdbProxima24Horas.Location = new System.Drawing.Point(28, 229);
            this.rdbProxima24Horas.Margin = new System.Windows.Forms.Padding(4);
            this.rdbProxima24Horas.Name = "rdbProxima24Horas";
            this.rdbProxima24Horas.Size = new System.Drawing.Size(308, 21);
            this.rdbProxima24Horas.TabIndex = 14;
            this.rdbProxima24Horas.TabStop = true;
            this.rdbProxima24Horas.Text = "Visualizar Compromissos próximas 24 Horas";
            this.rdbProxima24Horas.UseVisualStyleBackColor = true;
            // 
            // FiltroCompromissoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 316);
            this.Controls.Add(this.rdbProxima24Horas);
            this.Controls.Add(this.rdbProximaSemana);
            this.Controls.Add(this.rdbProximoMes);
            this.Controls.Add(this.rdbCompromissosPassados);
            this.Controls.Add(this.rdbCompromissosFuturos);
            this.Controls.Add(this.rdbTodosCompromissos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "FiltroCompromissoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Compromissos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbCompromissosPassados;
        private System.Windows.Forms.RadioButton rdbCompromissosFuturos;
        private System.Windows.Forms.RadioButton rdbTodosCompromissos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.RadioButton rdbProximoMes;
        private System.Windows.Forms.RadioButton rdbProximaSemana;
        private System.Windows.Forms.RadioButton rdbProxima24Horas;
    }
}

namespace eAgenda.WindowsApp.Features.Tarefas
{
    partial class FiltroTarefaForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.rdbTodasTarefas = new System.Windows.Forms.RadioButton();
            this.rdbTarefasPendentes = new System.Windows.Forms.RadioButton();
            this.rdbTarefasConcluidas = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(276, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(195, 193);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 2;
            this.btnGravar.Text = "Filtrar";
            this.btnGravar.UseVisualStyleBackColor = true;            
            // 
            // rdbTodasTarefas
            // 
            this.rdbTodasTarefas.AutoSize = true;
            this.rdbTodasTarefas.Location = new System.Drawing.Point(27, 29);
            this.rdbTodasTarefas.Name = "rdbTodasTarefas";
            this.rdbTodasTarefas.Size = new System.Drawing.Size(151, 17);
            this.rdbTodasTarefas.TabIndex = 4;
            this.rdbTodasTarefas.TabStop = true;
            this.rdbTodasTarefas.Text = "Visualizar todas as Tarefas";
            this.rdbTodasTarefas.UseVisualStyleBackColor = true;
            // 
            // rdbTarefasPendentes
            // 
            this.rdbTarefasPendentes.AutoSize = true;
            this.rdbTarefasPendentes.Location = new System.Drawing.Point(27, 63);
            this.rdbTarefasPendentes.Name = "rdbTarefasPendentes";
            this.rdbTarefasPendentes.Size = new System.Drawing.Size(200, 17);
            this.rdbTarefasPendentes.TabIndex = 5;
            this.rdbTarefasPendentes.TabStop = true;
            this.rdbTarefasPendentes.Text = "Visualizar somente tarefas pendentes";
            this.rdbTarefasPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTarefasConcluidas
            // 
            this.rdbTarefasConcluidas.AutoSize = true;
            this.rdbTarefasConcluidas.Location = new System.Drawing.Point(27, 97);
            this.rdbTarefasConcluidas.Name = "rdbTarefasConcluidas";
            this.rdbTarefasConcluidas.Size = new System.Drawing.Size(203, 17);
            this.rdbTarefasConcluidas.TabIndex = 6;
            this.rdbTarefasConcluidas.TabStop = true;
            this.rdbTarefasConcluidas.Text = "Visualizar somente tarefas concluídas";
            this.rdbTarefasConcluidas.UseVisualStyleBackColor = true;
            // 
            // FiltroTarefaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 234);
            this.Controls.Add(this.rdbTarefasConcluidas);
            this.Controls.Add(this.rdbTarefasPendentes);
            this.Controls.Add(this.rdbTodasTarefas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroTarefaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Tarefas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.RadioButton rdbTodasTarefas;
        private System.Windows.Forms.RadioButton rdbTarefasPendentes;
        private System.Windows.Forms.RadioButton rdbTarefasConcluidas;
    }
}
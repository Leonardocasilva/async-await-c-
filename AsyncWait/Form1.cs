using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Faço a disativação do botão
            button1.Enabled = false;

            // A Sintax seria essa, caso nos utilizasemos Task
            // Task<string> t = Task.Run(() => GetHTML());

            /* Asyn await task
             * Aqui aplico o await, para sobre a task, 
             * fazendo assim com que a chamada do metodo seja asincrona,
             * lembrado que usamos lambda para informar que, estaremos
             * chamando um metodo e que o retorno do mesmo deve ser atribuido
             * a varivael html, desse jeito também não há a necessidade de deixar
             * explicito, qual é o tipo da task, como no exemplo de task acima.
             */

            string html = await Task.Run(() => GetHTML());
            richTextBox1.Text = html;

            /*
             * Você pode comentar as duas linhas acima e descomentas esta
             * para ver a diferença na execução, do metodo, com o Async,
             * e sem ele, vera que a aplicação ira "Travar" e você não
             * conseguira efetuar nenhuma outra ação até que o retorno
             * seja realizado.
             */
            // richTextBox1.Text = GetHTML();

            // Reabbilito o botão
            button1.Enabled = true;
        }

        // Methodo executara em segundo plano
        private string GetHTML()
        {
            // Crio um  WebClient para utilizar na abstração dop HTML
            WebClient wc = new WebClient();

            // Utilizo o Objeto para definir o Encoding a ser usado
            wc.Encoding = Encoding.UTF8;

            // Adiciono o Thead Sleep apenas para aumentar o Delay do processamento
            Thread.Sleep(5000);

            // Retorno o HTML abstraido de uma pagina qualquer, nesse caso, da pagina da google
            return wc.DownloadString("http://www.google.com.br");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using ComponentFactory.Krypton.Toolkit;

namespace megalodon
{
    public partial class user_registration : KryptonForm
    {
        string priKey;
        string pubKey;
        public user_registration()
        {
            InitializeComponent();
        }

        private void user_registration_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkUsername_Click(object sender, EventArgs e)
        {
            try
            {
                //This block will be used to check that the provided username is not already in the database.
                var checkUsername = usernameBox.Text;
            }

            catch
            {

            }
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            RsaEncryption rsa = new RsaEncryption();

            priKey = rsa.GetPrivateKey();
            pubKey = rsa.GetPublicKey();

            SaveFileDialog save = new SaveFileDialog();

            save.Title = "Save Private Key";
            save.Filter = "Key File (*.key|*.key| All Files (*.*)|*.*";
            save.DefaultExt = ".key";
            save.FileName = String.Format("{0}.key", rsaKeyBox.Text);
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);

                write.Write(priKey);
                write.Dispose();
            }
        }
    }

    public class RsaEncryption
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privayeKey;
        private RSAParameters _publicKey;

        public RsaEncryption()
        {
            _privayeKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

        public string GetPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publicKey);

            return sw.ToString();
        }

        public string GetPrivateKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));

            xs.Serialize(sw, _privayeKey);

            return sw.ToString();
        }
    }
}

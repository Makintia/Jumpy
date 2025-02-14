using System.IO;
using NUnit.Framework;

namespace Tests.Editor
{
    public class AssetTest
    {

        [Test] //������� ����
        public void AssetValidate() //�������� �����
        {

            var assetDirectoryPath = "Assets/Editor/"; //�� ����� ����
            var filePaths = Directory.GetFiles(assetDirectoryPath, "*.cs"); //������� ����� � �����������

            foreach (var path in filePaths)
            {
                Validate(path); //��������� ���� ��� ������� �����
            }
        }

        private void Validate(string path)
        {
            var fileName = Path.GetFileName(path); //�������� ����� ������


            Assert.IsNotNull($"{fileName} => asset is null"); //����������, ��� ����� ������ ����������

        }
    }
}
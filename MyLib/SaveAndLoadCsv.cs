using MyLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLib
{
    public class SaveAndLoadCsv

    {
        private const string CsvSeparator = "←";
        public static void SaveTreeToCsv(AutoTree autoTree)  // Принимает AutoTree
        {
            // Используем SaveFileDialog (для выбора пути)
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные дерева в CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // Обходим все деревья в списке
                        foreach (TreeNodeModel root in autoTree.GetData()) // Используем GetData()
                        {
                            TraverseTree(root, writer, "", CsvSeparator);
                        }
                    }
                
             
            }
        }

        private static void TraverseTree(TreeNodeModel node, StreamWriter writer, string parentName, string separator)
        {
            if (node == null) return;

            // Формируем CSV-строку
            string csvLine = $"{node.Name}{separator}{parentName}";
            writer.WriteLine(csvLine);

            // Рекурсивно обходим дочерние узлы
            foreach (TreeNodeModel child in node.Children)
            {
                TraverseTree(child, writer, node.Name, separator);
            }
        }

        

    }
}


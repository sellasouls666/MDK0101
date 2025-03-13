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
        public static void SaveTreeToCsv(AutoTree autoTree)
        {
            // Используем SaveFileDialog (для выбора пути)
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные дерева в CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // Записываем заголовки CSV (уже без экранирования, просто строка)
                        writer.WriteLine("Название" + CsvSeparator + "Родитель");

                        // Обходим все деревья в списке
                        foreach (TreeNodeModel root in autoTree.GetData())
                        {
                            TraverseTree(root, writer, "", CsvSeparator);
                        }
                    }
                    Console.WriteLine($"Tree data saved to {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
                }
            }
        }

        private static void TraverseTree(TreeNodeModel node, StreamWriter writer, string parentName, string separator)
        {
            if (node == null) return;

            // Формируем CSV-строку (уже без экранирования, просто конкатенация)
            string csvLine = $"{node.Name}{separator}{parentName}";
            writer.WriteLine(csvLine);

            // Рекурсивно обходим дочерние узлы
            foreach (TreeNodeModel child in node.Children)
            {
                TraverseTree(child, writer, node.Name, separator);
            }
        }

        public static AutoTree LoadTreeFromCsv()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Загрузить данные дерева из CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    AutoTree autoTree = new AutoTree(); // Создаем новый экземпляр AutoTree
                    List<TreeNodeModel> rootNodes = autoTree.GetData(); // Получаем список корневых узлов
                    rootNodes.Clear(); // Очищаем дефолтные узлы

                    Dictionary<string, TreeNodeModel> nodeMap = new Dictionary<string, TreeNodeModel>();

                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    if (lines.Length > 1) // Пропускаем заголовок
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(new string[] { CsvSeparator }, StringSplitOptions.None);

                            if (values.Length == 2)
                            {
                                string name = values[0]; // Нет экранирования
                                string parentName = values[1]; // Нет экранирования

                                TreeNodeModel node = new TreeNodeModel(name);
                                nodeMap[name] = node;

                                if (string.IsNullOrEmpty(parentName))
                                {
                                    // Это корневой узел
                                    rootNodes.Add(node);
                                }
                                else
                                {
                                    // Ищем родительский узел
                                    if (nodeMap.ContainsKey(parentName))
                                    {
                                        TreeNodeModel parentNode = nodeMap[parentName];
                                        parentNode.Children.Add(node);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Предупреждение: Не найден родительский узел с именем '{parentName}' для узла '{name}'.");
                                        rootNodes.Add(node); // Если родитель не найден, добавляем как корневой
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Предупреждение: Неправильный формат строки в CSV файле: '{lines[i]}'");
                            }
                        }
                    }
                    return autoTree; // Возвращаем созданное дерево
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
                    return new AutoTree(); // Возвращаем пустое дерево в случае ошибки
                }
            }
            return null;  // Если диалог отменен, возвращаем null
        }
    }
 }



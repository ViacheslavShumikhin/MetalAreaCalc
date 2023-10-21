using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MetalCalcLibrary;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using MetalAreaCalc.Forms;

namespace MetalAreaCalc
{
    public partial class MainForm : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager; //Создаем переменную для записи значений
        private readonly Database _db = new Database();
        private DatabaseLists databaseLists;
        private bool isLoaded = false; // Переменная для хранения состояния загрузки списков


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        public MainForm()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

        }
        //
        //Настройки цветовой темы
        //

        private int colorSchemeIndex;

        private void btnChangeColor_Click(object sender, EventArgs e) //Смена цвета
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;
            updateColor();
        }

        private void btnChangeTheme_Click(object sender, EventArgs e) //Смена темы
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            updateColor();
        }

        private void updateColor()
        {
            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;

                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    break;

                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
            }
            Invalidate();
        }

        //Свичи настройки темы
        private void mtrSwitchUseColors_CheckedChanged(object sender, EventArgs e)
        {
            DrawerUseColors = mtrSwitchUseColors.Checked;
        }

        private void mtrSwitchHigthLight_CheckedChanged(object sender, EventArgs e)
        {
            DrawerHighlightWithAccent = mtrSwitchHigthLight.Checked;
        }

        private void mtrSwitchBackground_CheckedChanged(object sender, EventArgs e)
        {
            DrawerBackgroundWithAccent = mtrSwitchBackground.Checked;
        }

        private void mtrSwitchIconsHidden_CheckedChanged(object sender, EventArgs e)
        {
            DrawerShowIconsWhenHidden = mtrSwitchIconsHidden.Checked;
        }

        private void mtrSwitchAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            DrawerAutoShow = mtrSwitchAutoShow.Checked;
        }
        //Кнопка обновить Сортамент
        private void btnSortament_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр класса Database и вызываем метод OpenConnection для открытия соединения с базой данных
            Database db = new Database();
            db.OpenConnection();

            // Выполняем запрос к базе данных для получения списка сортамента
            string query = "SELECT * FROM Sorts";
            DataTable dt = db.ExecuteQuery(query);

            // Очищаем таблицу "materialListSorts" перед заполнением
            materialListSorts.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                // Создаем новый объект ListViewItem и добавляем его в коллекцию Items
                ListViewItem item = new ListViewItem(row["ID"].ToString());
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["Gost"].ToString());
                // Присваиваем значение свойству Tag элемента списка materialListSorts
                item.Tag = row["ID"].ToString();
                materialListSorts.Items.Add(item);
            }

            // Закрытие соединения с базой данных
            db.CloseConnection();

            // Закрытие тунеля
            db.CloseTunnel();
        }
        //Кнопка обновить проект
        private void btnProjectUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                // Создаем экземпляр класса Database и вызываем метод OpenConnection для открытия соединения с базой данных
                Database db = new Database();
                db.OpenConnection();

                // Получаем идентификатор пользователя по его логину
                string getUserIdQuery = $"SELECT ID FROM Users WHERE Login = '{User.Login}'";
                int userId = Convert.ToInt32(db.ExecuteScalar(getUserIdQuery));

                // Выполняем запрос к базе данных с условием, что UserID равен идентификатору текущего пользователя
                string query = $"SELECT * FROM Projects WHERE UserID = {userId}";
                DataTable dt = db.ExecuteQuery(query);

                // Заполнение materialListProjects данными из таблицы Projects
                materialListProjects.Items.Clear(); // очистим список перед заполнением

                foreach (DataRow row in dt.Rows)
                {
                    // создаем новый объект ListViewItem и добавляем его в коллекцию Items
                    ListViewItem item = new ListViewItem(row["Name"].ToString());
                    item.SubItems.Add(row["Tonnage"].ToString());
                    item.SubItems.Add(row["Area"].ToString());
                    item.SubItems.Add(row["CreationDate"].ToString());
                    // Присваиваем значение свойству Tag элемента списка materialListProjects
                    item.Tag = row["ID"].ToString();
                    materialListProjects.Items.Add(item);
                }

                // Закрытие соединения с базой данных
                db.CloseConnection();

                // Закрытие тунеля
                db.CloseTunnel();
            }
            else
            {
                AuthorizationError authorizationError = new AuthorizationError();
                authorizationError.Show();
            }

        }

        private void materialListProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем ID выбранного проекта из materialListProjects
            int projectID = -1;
            if (materialListProjects.SelectedItems.Count > 0)
            {
                ListViewItem selectedProject = materialListProjects.SelectedItems[0];
                projectID = Convert.ToInt32(selectedProject.Tag);
            }
            //Если проект не выбран, очищаем список materialListProjectElements
            if (projectID == -1)
            {
                materialListProjectElements.Items.Clear();
                return;
            }

            // Создаем экземпляр класса Database и вызываем метод OpenConnection для открытия соединения с базой данных
            Database db = new Database();
            db.OpenConnection();

            // Выполняем запрос к базе данных
            string query = "SELECT pe.Tonnage, pe.Area, pe.Meterage, s.Name as SortName, s.Gost, e.Name as ElementName " +
                           "FROM ProjectElements pe " +
                           "JOIN Elements e ON pe.ElementID = e.ID " +
                           "JOIN Sorts s ON e.SortID = s.ID " +
                           "WHERE pe.ProjectID = " + projectID;
            DataTable dt = db.ExecuteQuery(query);

            // Заполнение materialListProjectElements данными из таблицы ProjectElements
            materialListProjectElements.Items.Clear(); // очистим список перед заполнением

            foreach (DataRow row in dt.Rows)
            {
                // создаем новый объект ListViewItem и добавляем его в коллекцию Items
                ListViewItem item = new ListViewItem(row["SortName"].ToString());
                item.SubItems.Add(row["Gost"].ToString());
                item.SubItems.Add(row["ElementName"].ToString());
                item.SubItems.Add(row["Tonnage"].ToString());
                item.SubItems.Add(row["Meterage"].ToString());
                item.SubItems.Add(row["Area"].ToString());
                materialListProjectElements.Items.Add(item);
            }

            // Закрытие соединения с базой данных
            db.CloseConnection();

            // Закрытие тунеля
            db.CloseTunnel();

        }
        public void LoadDatabaseLists()
        {
            // Создаем новый экземпляр класса Database
            Database db = new Database();

            try
            {
                db.OpenConnection();

                // Создаем экземпляр класса DatabaseLists для загрузки списков из базы данных
                DatabaseLists databaseLists = new DatabaseLists(db);
                databaseLists.Load();

                // Устанавливаем источник данных для столбца Sorts (столбец №2)
                DataGridViewComboBoxColumn sortsColumn = dataGridViewCalc.Columns[1] as DataGridViewComboBoxColumn;
                sortsColumn.DataSource = databaseLists.Sorts;
                sortsColumn.DisplayMember = "Name";
                sortsColumn.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                // Обрабатываем исключение
                MessageBox.Show("Ошибка загрузки данных из базы данных: " + ex.Message);
            }
            finally
            {
                // Закрываем соединение с базой данных
                db.CloseConnection();
                db.CloseTunnel();
            }
        }
        private void dataGridViewCalc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Проверяем, было ли изменено значение в столбце "Sorts" (№1)
            if (e.ColumnIndex == 1)
            {
                var selectedValue = dataGridViewCalc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (selectedValue != null)
                {
                    var sortID = Convert.ToInt32(selectedValue);
                    var sort = databaseLists.Sorts.FirstOrDefault(s => s.ID == sortID);
                    if (sort != null)
                    {
                        dataGridViewCalc.Rows[e.RowIndex].Cells[2].Value = sort.Gost;

                        // Очищаем столбец "ElementName" (№3)
                        dataGridViewCalc.Rows[e.RowIndex].Cells[3].Value = null;
                    }
                }
            }

            // Проверяем, было ли изменено значение в столбце "Tonnage" (№4)
            if (e.ColumnIndex == 4)
            {
                var tonnageCell = dataGridViewCalc.Rows[e.RowIndex].Cells[4];
                // Если значение не пустое
                if (tonnageCell.Value != null)
                {
                    double tonnage;
                    if (Double.TryParse(tonnageCell.Value.ToString(), out tonnage))
                    {
                        // Проверяем отрицательное ли число
                        if (tonnage < 0)
                        {
                            // Очищаем значения столбцов 4, 5 и 6
                            dataGridViewCalc.Rows[e.RowIndex].Cells[4].Value = null;
                            dataGridViewCalc.Rows[e.RowIndex].Cells[5].Value = null;
                            dataGridViewCalc.Rows[e.RowIndex].Cells[6].Value = null;
                            return;
                        }

                        Element element = GetSelectedElement(e); // Получаем элемент, соответствующий текущей строке

                        // Проверяем, было ли изменено значение в столбце "Sorts" (№1)
                        var sortsCell = dataGridViewCalc.Rows[e.RowIndex].Cells[1];
                        if (sortsCell.Value != null && !sortsCell.Value.Equals(element.SortID))
                        {
                            // Очищаем значения следующих столбцов
                            ClearNextColumnsValues(e.RowIndex, 2); // Очищаем столбец "Gost" (№2)
                            ClearNextColumnsValues(e.RowIndex, 3); // Очищаем столбец "ElementName" (№3)
                        }

                        double area = Math.Round(tonnage * element.AreaPerTon, 3); // Считаем площадь и округляем до 3 знаков, используя AreaPerTon выбранного элемента
                        dataGridViewCalc.Rows[e.RowIndex].Cells[6].Value = area;
                        double massOneMeter = Math.Round(tonnage * 1000 / element.MassOneMeter, 3); // Рассчитываем значение и округляем до 3 знаков
                        dataGridViewCalc.Rows[e.RowIndex].Cells[5].Value = massOneMeter;
                    }
                    else
                    {
                        // Очищаем поле, так как введено не число
                        tonnageCell.Value = null;
                    }
                }
            }

            // Проверяем, было ли изменено значение в столбце "Metrage" (№5)
            else if (e.ColumnIndex == 5)
            {
                var metrageCell = dataGridViewCalc.Rows[e.RowIndex].Cells[5];

                // Если значение не пустое
                if (metrageCell.Value != null)
                {
                    double metrage;
                    if (Double.TryParse(metrageCell.Value.ToString(), out metrage))
                    {
                        // Проверяем отрицательное ли число
                        if (metrage < 0)
                        {
                            // Очищаем значения столбцов 4, 5 и 6
                            dataGridViewCalc.Rows[e.RowIndex].Cells[4].Value = null;
                            dataGridViewCalc.Rows[e.RowIndex].Cells[5].Value = null;
                            dataGridViewCalc.Rows[e.RowIndex].Cells[6].Value = null;
                            return;
                        }

                        Element element = GetSelectedElement(e); // Получаем элемент, соответствующий текущей строке

                        // Проверяем, было ли изменено значение в столбце "Sorts" (№1)
                        var sortsCell = dataGridViewCalc.Rows[e.RowIndex].Cells[1];
                        if (sortsCell.Value != null && !sortsCell.Value.Equals(element.SortID))
                        {
                            // Очищаем значения следующих столбцов
                            ClearNextColumnsValues(e.RowIndex, 2); // Очищаем столбец "Gost" (№2)
                            ClearNextColumnsValues(e.RowIndex, 3); // Очищаем столбец "ElementName" (№3)
                        }

                        dataGridViewCalc.Rows[e.RowIndex].Cells[4].Value = Math.Round(metrage * element.MassOneMeter / 1000, 3);
                        double area = Math.Round(metrage * element.MassOneMeter / 1000 * element.AreaPerTon, 3);
                        dataGridViewCalc.Rows[e.RowIndex].Cells[6].Value = area;
                        UpdateTotalArea();
                        UpdateTotalTonnage();
                    }
                    else
                    {
                        // Очищаем поле, так как введено не число
                        metrageCell.Value = null;
                    }
                }
            }
        }



        // Метод для очистки значений следующих столбцов, начиная с указанного индекса
        private void ClearNextColumnsValues(int rowIndex, int startIndex)
        {
            for (int columnIndex = startIndex; columnIndex < dataGridViewCalc.Columns.Count; columnIndex++)
            {
                dataGridViewCalc.Rows[rowIndex].Cells[columnIndex].Value = null;
            }
        }

        // Получаем элемент, соответствующий выбранному сорту в текущей строке
        private Element GetSelectedElement(DataGridViewCellEventArgs e)
        {
            // Получаем выбранную строку
            var selectedRow = dataGridViewCalc.Rows[e.RowIndex];
            // Получаем выбранное значение из столбца №2
            var selectedValue = selectedRow.Cells[1].Value?.ToString();
            // Получаем выбранное значение из столбца №3 (ElementName)
            var elementName = selectedRow.Cells[3].Value?.ToString();

            // Ищем элементы с соответствующим SortID
            var elementsWithSortID = databaseLists.Elements.Where(a => a.SortID.ToString() == selectedValue);
            // Ищем элемент с соответствующим SortID и ElementName
            var element = elementsWithSortID.FirstOrDefault(a => a.Name == elementName);

            var areaPerTon = element?.AreaPerTon;
            var massOneMeter = element?.MassOneMeter;

            return element;
        }

        private void LoadSortsToComboBox()
        {
            var comboBoxColumn = dataGridViewCalc.Columns[1] as DataGridViewComboBoxColumn;
            if (comboBoxColumn != null)
            {
                var items = new List<Sort>();
                foreach (var sort in databaseLists.Sorts)
                {
                    items.Add(new Sort
                    {
                        ID = sort.ID,
                        Name = sort.Name,
                        Gost = sort.Gost
                    });
                }
                comboBoxColumn.DataSource = items;
                comboBoxColumn.DisplayMember = "Name";
                comboBoxColumn.ValueMember = "ID";
            }
        }

        private void LoadElementName(object sender, DataGridViewCellEventArgs d)
        {
            databaseLists.Load();

            // Получаем выбранную строку
            var selectedRow = dataGridViewCalc.Rows[d.RowIndex];

            // Получаем выбранное значение из столбца №2
            var selectedValue = selectedRow.Cells[1].Value?.ToString();

            // Проверяем, что ячейка №4 является DataGridViewComboBoxCell
            if (selectedRow.Cells[3] is DataGridViewComboBoxCell comboBoxCell)
            {
                // Ищем соответствующий SortID в списке Sorts
                var selectedSort = databaseLists.Sorts.FirstOrDefault(s => s.ID.ToString() == selectedValue);

                if (selectedSort != null)
                {
                    // Ищем соответствующие значения ElementName для выбранного SortID
                    var elementNames = databaseLists.Elements.Where(e => e.SortID == selectedSort.ID)
                                                              .Select(e => e.Name)
                                                              .ToList();

                    // Обновляем значения в DataGridViewComboBoxColumn
                    comboBoxCell.DataSource = elementNames;
                }
                else
                {
                    // Если значение в столбце №2 не выбрано или не найдено в списке Sorts,
                    // то очищаем значения в DataGridViewComboBoxColumn
                    comboBoxCell.DataSource = null;
                    comboBoxCell.Value = null;
                }
            }
        }

        private void dataGridViewCalc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                LoadSortsToComboBox();
            }

            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                LoadElementName(this, e);
            }
        }

        private void btnLoadLists_Click(object sender, EventArgs e)
        {
            _db.OpenConnection();
            databaseLists = new DatabaseLists(_db);
            databaseLists.Load();
            _db.CloseConnection();
            _db.CloseTunnel();
            isLoaded = true; // Установить флаг загрузки списков в true
        }

        private void UpdateTotalArea()
        {
            double totalArea = 0;

            foreach (DataGridViewRow row in dataGridViewCalc.Rows)
            {
                if (row.Cells[6].Value != null)
                {
                    totalArea += Convert.ToDouble(row.Cells[6].Value);
                }
            }

            materialLabelArea.Text = totalArea.ToString();
        }

        private void UpdateTotalTonnage()
        {
            double totalTonnage = 0;

            foreach (DataGridViewRow row in dataGridViewCalc.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    totalTonnage += Convert.ToDouble(row.Cells[4].Value);
                }
            }

            materialLabelTonnage.Text = totalTonnage.ToString();
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = $"Расчет площади покраски";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(saveFileDialog.FileName, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet 1" };
                    sheets.Append(sheet);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Сортамент");
                    dt.Columns.Add("ГОСТ");
                    dt.Columns.Add("Наименование элемента");
                    dt.Columns.Add("Масса, тонн");
                    dt.Columns.Add("Длина, метров");
                    dt.Columns.Add("Площадь, м2");

                    // Добавляем строки DataGridView в DataTable
                    foreach (DataGridViewRow row in dataGridViewCalc.Rows)
                    {
                        DataRow dtRow = dt.NewRow();
                        dtRow["Сортамент"] = row.Cells[0].Value;
                        dtRow["ГОСТ"] = row.Cells[1].Value;
                        dtRow["Наименование элемента"] = row.Cells[2].Value;
                        dtRow["Масса, тонн"] = row.Cells[3].Value;
                        dtRow["Длина, метров"] = row.Cells[4].Value;
                        dtRow["Площадь, м2"] = row.Cells[5].Value;
                        dt.Rows.Add(dtRow);
                    }

                    // Добавляем значения TextBox в DataTable
                    DataRow newDtRow = dt.NewRow();
                    newDtRow["Сортамент"] = mtbProjectName.Text;
                    newDtRow["ГОСТ"] = mtrCustomer.Text;
                    newDtRow["Наименование элемента"] = mtbProjectNumber.Text;
                    newDtRow["Масса, тонн"] = mtbContactName.Text;
                    newDtRow["Длина, метров"] = mtbContactInfo.Text;
                    newDtRow["Площадь, м2"] = mtbEmail.Text;
                    dt.Rows.Add(newDtRow);

                    // Записываем DataTable в Excel
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        Row row = new Row();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(dataRow[i].ToString());
                            row.AppendChild(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                }

                MessageBox.Show("Файл успешно сохранен");
            }
        }



        private void btnClean_Click(object sender, EventArgs e)
        {
            // Очистка формы калькулятора
            // Очищаем таблицу
            dataGridViewCalc.Rows.Clear();
            //Очищаем прочие поля
            mtbProjectName.Text = "Название проекта";
            mtbProjectNumber.Text = "Шифр проекта";
            mtrCustomer.Text = "Заказчик";
            mtbContactName.Text = "Контактное лицо";
            mtbContactInfo.Text = "Контактная информация";
            mtbEmail.Text = "Электронная почта";
            materialLabelArea.Text = "0";
            materialLabelTonnage.Text = "0";

        }

        private void btnProjectChange_Click(object sender, EventArgs e)
        {
            if (isLoaded) // Проверка загрузки
            {
                // Код, выполняющийся при загрузке
                if (!string.IsNullOrEmpty(User.Login))
                {
                    projectLoadList();
                }
                else
                {
                    AuthorizationError authorizationError = new AuthorizationError();
                    authorizationError.Show();
                }
            }
            else
            {
                // Код, выполняющийся при отсутствии загрузки
                btnLoadLists_Click(sender, e); // Загрузка списков

                // Код, который должен быть выполнен после загрузки
                if (!string.IsNullOrEmpty(User.Login))
                {
                    projectLoadList();
                }
                else
                {
                    AuthorizationError authorizationError = new AuthorizationError();
                    authorizationError.Show();
                }
            }
        }

        private void projectLoadList()
        {
            // Проверяем, выбран ли проект
            if (materialListProjects.SelectedItems.Count > 0)
            {
                // Настраиваем индексы столбцов
                dataGridViewCalc.Columns[0].DisplayIndex = 0;
                dataGridViewCalc.Columns[1].DisplayIndex = 1;
                dataGridViewCalc.Columns[2].DisplayIndex = 2;
                dataGridViewCalc.Columns[3].DisplayIndex = 3;
                dataGridViewCalc.Columns[4].DisplayIndex = 4;
                dataGridViewCalc.Columns[5].DisplayIndex = 5;
                dataGridViewCalc.Columns[6].DisplayIndex = 6;

                dataGridViewCalc.DataError += DataGridViewCalc_DataError;


                // Получаем ID выбранного проекта 
                int projectId = Convert.ToInt32(materialListProjects.SelectedItems[0].Tag);

                try
                {
                    // Создаем экземпляр класса Database и открываем соединение
                    Database db = new Database();
                    db.OpenConnection();

                    // Получаем данные проекта из базы данных
                    string getProjectQuery = $"SELECT * FROM Projects WHERE ID = {projectId}";
                    DataTable projectData = db.ExecuteQuery(getProjectQuery);

                    if (projectData.Rows.Count > 0)
                    {
                        // Настройки столбца №1 (Sorts)
                        var sortsColumn = (DataGridViewComboBoxColumn)dataGridViewCalc.Columns[1];
                        sortsColumn.DataSource = databaseLists.Sorts;
                        sortsColumn.DisplayMember = "Name";
                        sortsColumn.ValueMember = "ID";

                        // Настройки столбца №3 (ElementName)
                        var elementNameColumn = (DataGridViewComboBoxColumn)dataGridViewCalc.Columns[3];
                        elementNameColumn.DataSource = databaseLists.Elements;
                        elementNameColumn.DisplayMember = "Name";
                        elementNameColumn.ValueMember = "ID";

                        DataRow projectRow = projectData.Rows[0];
                        string projectName = projectRow["Name"].ToString();
                        double tonnage = Convert.ToDouble(projectRow["Tonnage"]);
                        double area = Convert.ToDouble(projectRow["Area"]);
                        int projectContactId = Convert.ToInt32(projectRow["ProjectContactID"]);

                        // Получаем данные контакта проекта из базы данных
                        string getProjectContactQuery = $"SELECT * FROM ProjectContacts WHERE ID = {projectContactId}";
                        DataTable projectContactData = db.ExecuteQuery(getProjectContactQuery);

                        if (projectContactData.Rows.Count > 0)
                        {
                            DataRow projectContactRow = projectContactData.Rows[0];
                            string projectNumber = projectContactRow["ProjectNumber"].ToString();
                            string customer = projectContactRow["Customer"].ToString();
                            string contactName = projectContactRow["ContactName"].ToString();
                            string contactInfo = projectContactRow["ContactInfo"].ToString();
                            string email = projectContactRow["ProjectEmail"].ToString();

                            // Заполняем поля в приложении
                            mtbProjectName.Text = projectName;
                            mtbProjectNumber.Text = projectNumber;
                            mtrCustomer.Text = customer;
                            mtbContactName.Text = contactName;
                            mtbContactInfo.Text = contactInfo;
                            mtbEmail.Text = email;
                            materialLabelArea.Text = area.ToString();
                            materialLabelTonnage.Text = tonnage.ToString();

                            // Получаем данные элементов проекта из базы данных
                            string getProjectElementsQuery = $"SELECT * FROM ProjectElements WHERE ProjectID = {projectId}";
                            DataTable projectElementsData = db.ExecuteQuery(getProjectElementsQuery);

                            // Очищаем существующие строки в DataGridView
                            dataGridViewCalc.Rows.Clear();

                            foreach (DataRow projectElementRow in projectElementsData.Rows)
                            {
                                int elementId = Convert.ToInt32(projectElementRow["ElementID"]);
                                double elementTonnage = Convert.ToDouble(projectElementRow["Tonnage"]);
                                double elementArea = Convert.ToDouble(projectElementRow["Area"]);
                                double elementLength = Convert.ToDouble(projectElementRow["Meterage"]);

                                // Получаем данные элемента из базы данных
                                string getElementQuery = $"SELECT * FROM Elements WHERE ID = {elementId}";
                                DataTable elementData = db.ExecuteQuery(getElementQuery);

                                if (elementData.Rows.Count > 0)
                                {
                                    DataRow elementRow = elementData.Rows[0];
                                    string elementName = elementRow["Name"].ToString();
                                    string elementSortament = elementRow["SortID"].ToString();

                                    // Получаем данные сортамента из базы данных
                                    string getSortamentQuery = $"SELECT * FROM Sorts WHERE ID = {elementSortament}";
                                    DataTable sortamentData = db.ExecuteQuery(getSortamentQuery);

                                    if (sortamentData.Rows.Count > 0)
                                    {
                                        DataRow sortamentRow = sortamentData.Rows[0];
                                        string sortamentName = sortamentRow["Name"].ToString();
                                        string sortamentGost = sortamentRow["Gost"].ToString();

                                        // Добавляем строку в DataGridView
                                        dataGridViewCalc.Rows.Add(" ", sortamentName, sortamentGost, elementName, elementTonnage, elementLength, elementArea);
                                    }
                                }
                            }
                        }
                    }

                    // Закрываем соединение с базой данных
                    db.CloseConnection();
                    db.CloseTunnel();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Упс! Что-то пошло не так: {ex.Message}");
                    throw;
                }
            }
            else
            {
                // Не выбран проект, отображаем сообщение об ошибке
                MessageBox.Show("Пожалуйста, выберите проект из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Метод использует каскадное удаление
        private void mtbProjectDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                // Проверяем, выбран ли проект
                if (materialListProjects.SelectedItems.Count > 0)
                {
                    // Создаем экземпляр класса Database и открываем соединение
                    Database db = new Database();
                    db.OpenConnection();

                    // Получаем ID выбранного проекта
                    string projectName = materialListProjects.SelectedItems[0].SubItems[0].Text;
                    double projectTonnage = Convert.ToDouble(materialListProjects.SelectedItems[0].SubItems[1].Text);
                    double projectArea = Convert.ToDouble(materialListProjects.SelectedItems[0].SubItems[2].Text);

                    string getProjectIdQuery = $"SELECT ID FROM Projects WHERE Name = '{projectName}' AND Tonnage = {projectTonnage.ToString().Replace(',', '.')} AND Area = {projectArea.ToString().Replace(',', '.')}";
                    int projectId = Convert.ToInt32(db.ExecuteScalar(getProjectIdQuery));

                    try
                    {
                        // Удаляем проект из таблицы Projects
                        string deleteProjectQuery = $"DELETE FROM Projects WHERE ID = {projectId}";
                        db.ExecuteQuery(deleteProjectQuery);

                        // Закрываем соединение с базой данных
                        db.CloseConnection();
                        db.CloseTunnel();
                        

                    }
                    catch (Exception ex)
                    {
                        // Закрываем соединение с базой данных
                        db.CloseConnection();
                        db.CloseTunnel();
                        Console.WriteLine($"Упс! Что-то пошло не так: {ex.Message}");
                        throw;
                    }
                    btnProjectUpdate_Click(sender, e);
                    materialListProjectElements.Clear();
                }
                else
                {
                    // Не выбран проект, отображаем сообщение об ошибке
                    MessageBox.Show("Пожалуйста, выберите проект из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AuthorizationError authorizationError = new AuthorizationError();
                authorizationError.Show();
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                try
                {
                    // Получение данных из текстовых полей
                    string projectName = mtbProjectName.Text;
                    string projectNumber = mtbProjectNumber.Text;
                    string customer = mtrCustomer.Text;
                    string contactName = mtbContactName.Text;
                    string contactInfo = mtbContactInfo.Text;
                    string email = mtbEmail.Text;
                    double area = Convert.ToDouble(materialLabelArea.Text);
                    double tonnage = Convert.ToDouble(materialLabelTonnage.Text);

                    // Создание экземпляра класса Database
                    Database db = new Database();

                    // Открытие соединения
                    db.OpenConnection();

                    // Получение ID пользователя
                    string getUserIdQuery = $"SELECT ID FROM Users WHERE Login = '{User.Login}'";
                    int userId = Convert.ToInt32(db.ExecuteScalar(getUserIdQuery));

                    // Получение ID контакта проекта
                    string getProjectContactIdQuery = $"SELECT ID FROM ProjectContacts WHERE ProjectNumber = '{projectNumber}' AND Customer = '{customer}' AND ContactName = '{contactName}' AND ContactInfo = '{contactInfo}' AND ProjectEmail = '{email}'";
                    int projectContactId = Convert.ToInt32(db.ExecuteScalar(getProjectContactIdQuery));

                    // Подготовка запроса для получения ID проекта на основе введенных данных
                    string getProjectIdQuery = $"SELECT ID FROM Projects WHERE Name = '{projectName}' AND Tonnage = {tonnage.ToString().Replace(',', '.')} AND Area = {area.ToString().Replace(',', '.')} AND UserID = {userId} AND ProjectContactID = {projectContactId}";
                    int projectId = Convert.ToInt32(db.ExecuteScalar(getProjectIdQuery));

                    // Удаление данных из таблицы ProjectElements для выбранного проекта
                    string deleteProjectElementsQuery = $"DELETE FROM ProjectElements WHERE ProjectID = {projectId}";
                    db.ExecuteQuery(deleteProjectElementsQuery);

                    // Удаление данных из таблицы Projects для выбранного проекта
                    string deleteProjectQuery = $"DELETE FROM Projects WHERE ID = {projectId}";
                    db.ExecuteQuery(deleteProjectQuery);

                    // Удаление данных из таблицы ProjectsContacts для выбранного проекта
                    string deleteProjectContacts = $"DELETE FROM ProjectContacts WHERE ID = {projectContactId}";
                    db.ExecuteQuery(deleteProjectContacts);

                    // Закрытие соединения
                    db.CloseConnection();
                    db.CloseTunnel();

                    // Очистка формы
                    dataGridViewCalc.Rows.Clear();
                    mtbProjectName.Text = "Название проекта";
                    mtbProjectNumber.Text = "Шифр проекта";
                    mtrCustomer.Text = "Заказчик";
                    mtbContactName.Text = "Контактное лицо";
                    mtbContactInfo.Text = "Контактная информация";
                    mtbEmail.Text = "Электронная почта";
                    materialLabelArea.Text = "0";
                    materialLabelTonnage.Text = "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Упс! Что-то пошло не так: {ex.Message}");
                    throw;
                }
            }
            else
            {
                AuthorizationError authorizationError = new AuthorizationError();
                authorizationError.Show();
            }
        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                DateTime now = DateTime.Now;
                string creationDateValue = now.ToString("yyyy-MM-dd HH:mm:ss");
                // Получение данных из текстовых полей
                string projectName = mtbProjectName.Text;
                string projectNumber = mtbProjectNumber.Text;
                string customer = mtrCustomer.Text;
                string contactName = mtbContactName.Text;
                string contactInfo = mtbContactInfo.Text;
                string email = mtbEmail.Text;
                double area = Convert.ToDouble(materialLabelArea.Text);
                double tonnage = Convert.ToDouble(materialLabelTonnage.Text);

                try
                {
                    // Создание экземпляра класса Database
                    Database db = new Database();

                    // Открытие соединения
                    db.OpenConnection();

                    // Получение ID пользователя
                    string getUserIdQuery = $"SELECT ID FROM Users WHERE Login = '{User.Login}'";
                    int userId = Convert.ToInt32(db.ExecuteScalar(getUserIdQuery));

                    // Проверка, существует ли уже запись в таблице ProjectContacts для данного проекта
                    string checkProjectContactQuery = $"SELECT COUNT(*) " +
                                                      $"FROM ProjectContacts PC " +
                                                      $"JOIN Projects P ON PC.ID = P.ProjectContactID " +
                                                      $"JOIN Users U ON P.UserID = U.ID " +
                                                      $"WHERE PC.ProjectNumber = '{projectNumber}' " +
                                                      $"    AND U.Login = '{User.Login}'";
                    int existingProjectContactCount = Convert.ToInt32(db.ExecuteScalar(checkProjectContactQuery));

                    // Вставка или обновление данных в таблице ProjectContacts
                    if (existingProjectContactCount > 0)
                    {
                        // Обновление данных в таблице ProjectContacts
                        string updateProjectContactQuery = $"UPDATE ProjectContacts PC " +
                                                           $"JOIN Projects P ON PC.ID = P.ProjectContactID " +
                                                           $"JOIN Users U ON P.UserID = U.ID " +
                                                           $"SET PC.Customer = '{customer}', PC.ContactName = '{contactName}', PC.ContactInfo = '{contactInfo}', PC.ProjectEmail = '{email}' " +
                                                           $"WHERE PC.ProjectNumber = '{projectNumber}' " +
                                                           $"AND U.Login = '{User.Login}';";

                        db.ExecuteQuery(updateProjectContactQuery);
                    }
                    else
                    {
                        // Вставка новых данных в таблицу ProjectContacts
                        string insertProjectContactQuery = $"INSERT INTO ProjectContacts (ProjectNumber, Customer, ContactName, ContactInfo, ProjectEmail) " +
                                                           $"VALUES ('{projectNumber}', '{customer}', '{contactName}', '{contactInfo}', '{email}')";
                        db.ExecuteQuery(insertProjectContactQuery);
                    }

                    // Подготовка запроса для получения ID контакта проекта
                    string getProjectContactIdQuery = $"SELECT PC.ID " +
                                                      $"FROM ProjectContacts PC " +
                                                      $"JOIN Projects P ON PC.ID = P.ProjectContactID " +
                                                      $"JOIN Users U ON P.UserID = U.ID " +
                                                      $"WHERE PC.ProjectNumber = '{projectNumber}' " +
                                                      $"AND U.Login = '{User.Login}';";

                    int projectContactId = Convert.ToInt32(db.ExecuteScalar(getProjectContactIdQuery));

                    string checkProjectQuery = $"SELECT COUNT(*) FROM Projects P " +
                                               $"JOIN Users U ON P.UserID = U.ID " +
                                               $"WHERE P.Name = '{projectName}' AND U.Login = '{User.Login}'";

                    int existingProjectCount = Convert.ToInt32(db.ExecuteScalar(checkProjectQuery));

                    // Вставка или обновление данных в таблице Projects
                    if (existingProjectCount > 0)
                    {
                        // Обновление данных в таблице Projects
                        string updateProjectQuery = $"UPDATE Projects P " +
                                                  $"JOIN ProjectContacts PC ON P.ProjectContactID = PC.ID " +
                                                  $"JOIN Users U ON P.UserID = U.ID " +
                                                  $"SET P.Tonnage = '{tonnage.ToString().Replace(',', '.')}'," +
                                                  $"P.Area = '{area.ToString().Replace(',', '.')}'," +
                                                  $"P.UserID = {userId}," +
                                                  $"P.ProjectContactID = {projectContactId} " +
                                                  $"WHERE PC.ProjectNumber = '{projectNumber}' " +
                                                  $"AND U.Login = '{User.Login}';";

                        db.ExecuteQuery(updateProjectQuery);
                    }
                    else
                    {
                        // Вставка новых данных в таблицу Projects
                        string insertProjectQuery = $"INSERT INTO Projects (Name, CreationDate, Tonnage, Area, UserID, ProjectContactID) VALUES ('{projectName}', '{creationDateValue}', {tonnage.ToString().Replace(',', '.')}, {area.ToString().Replace(',', '.')}, {userId}, {projectContactId})";
                        db.ExecuteQuery(insertProjectQuery);
                    }

                    // Подготовка запроса для получения ID проекта на основе введенных данных
                    string getProjectIdQuery = $"SELECT ID FROM Projects WHERE Name = '{projectName}' AND UserID = {userId}";

                    int projectId = Convert.ToInt32(db.ExecuteScalar(getProjectIdQuery));

                    // Удаление старых данных из таблицы ProjectElements для выбранного проекта
                    string deleteProjectElementsQuery = $"DELETE FROM ProjectElements WHERE ProjectID = {projectId}";
                    db.ExecuteQuery(deleteProjectElementsQuery);

                    // Вставка данных из таблицы DataGridView в таблицу Element и ProjectElements
                    for (int i = 0; i < dataGridViewCalc.Rows.Count - 1; i++)
                    {
                        DataGridViewRow row = dataGridViewCalc.Rows[i];
                        string sortament = row.Cells["Sorts"].Value.ToString();
                        string gosd = row.Cells["Gost"].Value.ToString();
                        string elementName = row.Cells["ElementName"].Value.ToString();
                        double mass = Convert.ToDouble(row.Cells["Tonnage"].Value);
                        double length = Convert.ToDouble(row.Cells["Metrage"].Value);
                        double elementArea = Convert.ToDouble(row.Cells["AreaCalc"].Value);

                        // Получение ID элемента
                        string getElementIdQuery = $"SELECT ID FROM Elements WHERE Name = '{elementName}' AND SortID =  '{sortament}'";
                        int elementId = Convert.ToInt32(db.ExecuteScalar(getElementIdQuery));

                        // Вставка данных в таблицу ProjectElements
                        string insertProjectElementQuery = $"INSERT INTO ProjectElements (ProjectID, ElementID, Tonnage, Area, Meterage) VALUES ({projectId}, {elementId}, {mass.ToString().Replace(',', '.')}, {elementArea.ToString().Replace(',', '.')}, {length.ToString().Replace(',', '.')})";
                        db.ExecuteQuery(insertProjectElementQuery);
                    }

                    // Закрытие соединения
                    db.CloseConnection();
                    db.CloseTunnel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Упс! Что-то пошло не так: {ex.Message}");
                    throw;
                }
            }
            else
            {
                AuthorizationError authorizationError = new AuthorizationError();
                authorizationError.Show();
            }
        }

        private void mtbLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                MessageBox.Show("Вы уже авторизованы.", "Авторизация");
            }
            else
            {
                LoginForm loginForm = new LoginForm(); // Создаем экземпляр формы для входа/авторизации
                loginForm.Show(); // Отображаем форму для входа/авторизации
            }
        }

        private void mtbLogout_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                User.Logout(); // Выполняем действия для выхода из текущего аккаунта/пользователя
                LoginForm loginForm = new LoginForm(); // Создаем экземпляр формы для входа/авторизации
                loginForm.Show(); // Отображаем форму для входа/авторизации
                this.Hide(); // Скрываем текущую форму
            }
            else
            {
                LoginForm loginForm = new LoginForm(); // Создаем экземпляр формы для входа/авторизации
                loginForm.Show(); // Отображаем форму для входа/авторизации
            }
        }

        private void dataGridViewCalc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCalc.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Получаем ячейку кнопки
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridViewCalc.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Получаем строку, которой принадлежит кнопка
                DataGridViewRow selectedRow = buttonCell.OwningRow;

                // Проверяем, что выбранная строка не является новой строкой
                if (!selectedRow.IsNewRow)
                {
                    // Удаляем выбранную строку
                    dataGridViewCalc.Rows.Remove(selectedRow);
                }
            }
        }

        //Добавил в замен кнопки Загрузить списки, кнопку в дальнейшем уберу, когда разберусь как инициализировать данное нействие при инициализации формы. Пока она не дает загрузить,
        //Ошибка второго подключения
        private void materialTabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем выбранную вкладку
            if (materialTabMain.SelectedTab == tabCalc)
            {
                _db.OpenConnection();
                databaseLists = new DatabaseLists(_db);
                databaseLists.Load();
                _db.CloseConnection();
                _db.CloseTunnel();
                isLoaded = true; // Установить флаг загрузки в true
            }
        }

        private void DataGridViewCalc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Предотвращение возникновения исключения и обработка ошибки
            e.ThrowException = false;

            // Обработка ошибки ввода пользователя
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Недопустимое значение в ячейке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Login))
            {
                DateTime now = DateTime.Now;
                string creationDateValue = now.ToString("yyyy-MM-dd HH:mm:ss");
                // Получение данных из текстовых полей
                string projectName = mtbProjectName.Text;
                string projectNumber = mtbProjectNumber.Text;
                string customer = mtrCustomer.Text;
                string contactName = mtbContactName.Text;
                string contactInfo = mtbContactInfo.Text;
                string email = mtbEmail.Text;
                double area = Convert.ToDouble(materialLabelArea.Text);
                double tonnage = Convert.ToDouble(materialLabelTonnage.Text);

                try
                {
                    // Создание экземпляра класса Database
                    Database db = new Database();

                    // Открытие соединения
                    db.OpenConnection();

                    // Получение ID пользователя
                    string getUserIdQuery = $"SELECT ID FROM Users WHERE Login = '{User.Login}'";
                    int userId = Convert.ToInt32(db.ExecuteScalar(getUserIdQuery));

                    // Вставка данных в таблицу ProjectContacts
                    string insertProjectContactQuery = $"INSERT INTO ProjectContacts (ProjectNumber, Customer, ContactName, ContactInfo, ProjectEmail) VALUES ('{projectNumber}', '{customer}', '{contactName}', '{contactInfo}', '{email}')";
                    db.ExecuteQuery(insertProjectContactQuery);

                    // Получение ID контакта проекта
                    string getProjectContactIdQuery = $"SELECT ID FROM ProjectContacts WHERE ProjectNumber = '{projectNumber}' AND Customer = '{customer}' AND ContactName = '{contactName}' AND ContactInfo = '{contactInfo}' AND ProjectEmail = '{email}'";
                    int projectContactId = Convert.ToInt32(db.ExecuteScalar(getProjectContactIdQuery));

                    // Вставка данных в таблицу Projects
                    string insertProjectQuery = $"INSERT INTO Projects (Name, CreationDate, Tonnage, Area, UserID, ProjectContactID) VALUES ('{projectName}', '{creationDateValue}', {tonnage.ToString().Replace(',', '.')}, {area.ToString().Replace(',', '.')}, {userId}, {projectContactId})";
                    db.ExecuteQuery(insertProjectQuery);

                    // Подготовка запроса для получения ID проекта на основе введенных данных
                    string getProjectIdQuery = $"SELECT ID FROM Projects WHERE Name = '{projectName}' AND CreationDate = '{creationDateValue}' AND Tonnage = {tonnage.ToString().Replace(',', '.')} AND Area = {area.ToString().Replace(',', '.')} AND UserID = {userId} AND ProjectContactID = {projectContactId}";
                    int projectId = Convert.ToInt32(db.ExecuteScalar(getProjectIdQuery));

                    // Вставка данных из таблицы DataGridView в таблицу Element и ProjectElements
                    for (int i = 0; i < dataGridViewCalc.Rows.Count - 1; i++)
                    {
                        DataGridViewRow row = dataGridViewCalc.Rows[i];
                        string sortament = row.Cells["Sorts"].Value.ToString();
                        string gosd = row.Cells["Gost"].Value.ToString();
                        string elementName = row.Cells["ElementName"].Value.ToString();
                        double mass = Convert.ToDouble(row.Cells["Tonnage"].Value);
                        double length = Convert.ToDouble(row.Cells["Metrage"].Value);
                        double elementArea = Convert.ToDouble(row.Cells["AreaCalc"].Value);

                        // Получение ID элемента
                        // Получение ID элемента
                        string getElementIdQuery = $"SELECT ID FROM Elements WHERE Name = '{elementName}' AND SortID =  '{sortament}'";
                        int elementId = Convert.ToInt32(db.ExecuteScalar(getElementIdQuery));

                        // Вставка данных в таблицу ProjectElements
                        string insertProjectElementQuery = $"INSERT INTO ProjectElements (ProjectID, ElementID, Tonnage, Area, Meterage) VALUES ({projectId}, {elementId}, {mass.ToString().Replace(',', '.')}, {elementArea.ToString().Replace(',', '.')}, {length.ToString().Replace(',', '.')})";
                        db.ExecuteQuery(insertProjectElementQuery);
                    }

                    // Закрытие соединения
                    db.CloseConnection();
                    db.CloseTunnel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Упс! Что-то пошло не так: {ex.Message}");
                    throw;
                }
            }
            else
            {
                AuthorizationError authorizationError = new AuthorizationError();
                authorizationError.Show();
            }
        }

        private void dataGridViewCalc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewCalc.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
    }
}

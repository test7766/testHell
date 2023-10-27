using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
using System.Windows.Forms;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// ��������� ����� ������������� �� ������� "������ �����"
    /// </summary>
    public class FormChangeSeriesBuilder : IFormBuilder
    {
        #region ��������� ����������

        private PickListRow _pickListRow = null;
        private int _sessionId;

        private DescriptionControl _descriptionControl;
        private ChangeSeriesControl _changeSeriesControl;
        private ChangeSeriesControl _splitChangeSeriesControl;

        #endregion

        #region �����������

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="pickListRow">���������� � ������ ����������</param>
        /// <param name="sessionId">������ ������������ WMS</param>
        public FormChangeSeriesBuilder(PickListRow pickListRow, int sessionId)
        {
            _pickListRow = pickListRow;
            _sessionId = sessionId;
        }

        #endregion

        #region Implementation of IFormBuilder

        /// <summary>
        /// ��������� �������� ���������� ��� �����
        /// </summary>
        public List<BaseControl> Controls { get; set; }

        /// <summary>
        /// ����� ���������� ��������� ����������
        /// </summary>
        public void LoadControls()
        {
            // ���������� �����, �� ������� ����� ������������ �����
            //using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            //{
            //    _location = adapter.GetLocation((int)CorrectionReasons.OutOfStock, null, null,
            //                                    _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId).Trim();
            //}

            Controls = new List<BaseControl>();

            // ���������� � ������� ��������� ������ ������
            CurrentRowControl currentRow = new CurrentRowControl()
                                               {
                                                   Location = _pickListRow.Location,
                                                   Item = _pickListRow.Item,
                                                   Quantity = _pickListRow.Quantity.ToString(),
                                                   Series = _pickListRow.Series,
                                                   TabStop = false
                                               };
            Controls.Add(currentRow);

            _changeSeriesControl = new ChangeSeriesControl()
                                       {
                                           SplitEnabled = false,
                                           EditQuantityEnabled = false,
                                           OriginalQuantity = _pickListRow.Quantity,
                                           Quantity = _pickListRow.Quantity,
                                           PickList = _pickListRow,
                                           SessionID = _sessionId
                                       };
            _changeSeriesControl.ValueChanged += (field, value) => ParseFormValues(false, field, value);
            Controls.Add(_changeSeriesControl);

            _splitChangeSeriesControl = new ChangeSeriesControl()
                                            {
                                                QuantityLabel = "���������� 2:",
                                                SeriesLabel = "����� 2:",
                                                EditQuantityEnabled = true,
                                                OriginalQuantity = _pickListRow.Quantity,
                                                PickList = _pickListRow,
                                                SessionID = _sessionId
                                            };
            _splitChangeSeriesControl.ValueChanged += (field, value) => ParseFormValues(true, field, value);
            Controls.Add(_splitChangeSeriesControl);

            // �������� �������� �������
            _descriptionControl = new DescriptionControl()
                                      {
                                          Action = String.Format("�� ����������� ����������� ����� {0}", _pickListRow.Series),
                                          Count = _pickListRow.Quantity.ToString(CultureInfo.InvariantCulture),
                                          Description = String.Format("�������� �������: ����� {0} � ���������� {1} ����� ��������������� �� ��������� �����.", _pickListRow.Series, _pickListRow.Quantity),
                                          TabStop = false
                                      };
            Controls.Add(_descriptionControl);

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// ���������� ������� ��������� �������� �� ����� �������������
        /// </summary>
        /// <param name="field">���� �����</param>
        /// <param name="value">����� ��������</param>
        private void ParseFormValues(bool isSplitRow, string field, object value)
        {
            bool allowOk = true;

            if (field == "Quantity" && isSplitRow)
            {
                int splitQuantity = (int) value;
                _changeSeriesControl.Quantity = _pickListRow.Quantity - splitQuantity;
                _changeSeriesControl.RefreshForm();
                // _descriptionControl.Count = splitQuantity.ToString();
                //_descriptionControl.Description = String.Format("�������� �������: ����� {0} � ���������� {1} ����� ��������������� �� ����� {2}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series);
            }

            if (field == "Series")
            {
                //_descriptionControl.Description = String.Format("�������� �������: ����� {0} � ���������� {1} ����� ��������������� �� ����� {2}.", _pickListRow.Series, _pickListRow.Quantity, _pickListRow.Series);
            }

            _descriptionControl.Description = (_splitChangeSeriesControl.SplitChecked)
                ? String.Format("�������� �������: ����� \"{0}\" � ���������� {1} ����� ��������������� �� ����� \"{2}\" � ���������� {3} � ����� \"{4}\" � ���������� {5}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series, _changeSeriesControl.Quantity, _splitChangeSeriesControl.Series, _splitChangeSeriesControl.Quantity)
                : String.Format("�������� �������: ����� \"{0}\" � ���������� {1} ����� ��������������� �� ����� \"{2}\" � ���������� {3}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series, _changeSeriesControl.Quantity);


            //if (field == "Split" && isSplitRow)
            //{
            //    _changeSeriesControl.RefreshForm();
            //}

        //    if (field == "Quantity")
        //        _descriptionControl.Count = _quantityChange.CanceledQuantity.ToString();

        //    if (field == "MoveAllRemains")
        //        if ((bool)value)
        //        {
        //            try
        //            {
        //                // ���������� �����, �� ������� ����� ������������ �����
        //                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
        //                {
        //                    var res = adapter.CP_GetRemainsByLocation(_sessionId, _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId);
        //                    _allRemainsCount = (res != null) ? (int)res : 0;
        //                }
        //                if (_allRemainsCount > 0)
        //                    _descriptionControl.Description = String.Format("�������� �������: ���������� ���������� ����� ���������� �� ����� {0}.\n��������� ������� �� ����� {1} � ���������� {2} ����� ��������� �� ����� {0}.", _location, _pickListRow.Location, _allRemainsCount);
        //                else
        //                    _descriptionControl.Description = String.Format("�������� �������: ���������� ���������� ����� ���������� �� ����� {0}.\n��������� ������� �� ����� {1} �����������.", _location, _pickListRow.Location);

        //            }
        //            catch (Exception ex)
        //            {
        //                _descriptionControl.Description = String.Format("�������� �������: ���������� ���������� ����� ���������� �� ����� {0}.\n������ ��� ��������� ���������� �������:\n {1}.", _location, ex.Message);
        //            }
        //        }
        //        else
        //        {
        //            _descriptionControl.Description = String.Format("�������� �������: ���������� ���������� ����� ���������� �� ����� {0}.", _location);
        //            _allRemainsCount = 0;
        //        }

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = allowOk, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// ����� ���������� ������ �����
        /// </summary>
        public void SaveData()
        {
            // �������� ��������, ��������� �� �����
            if ((_changeSeriesControl.Quantity == 0)
                || (_splitChangeSeriesControl.SplitChecked && _splitChangeSeriesControl.Quantity == 0))
                ShowError("���� \"����������\" �� ����� ���� ������ ��� ��������� 0."); 
            else if ((String.IsNullOrEmpty(_changeSeriesControl.Series)) 
                || (_splitChangeSeriesControl.SplitChecked && String.IsNullOrEmpty(_splitChangeSeriesControl.Series)))
                ShowError("���� \"�����\" �� ����� ���� ������.");
            //else if ((_pickListRow.Series == _changeSeriesControl.Series)
            //    || (_splitChangeSeriesControl.SplitChecked && _pickListRow.Series == _splitChangeSeriesControl.Series))
            //    ShowError("���� \"�����\" ������ ���� ��������, ��� ������������� \"������ �����\".");
            else
            {
                var changedAmount = (int?)null;
                var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                {
                    SqlConnection connection = new SqlConnection(adapter.ConnectionString);
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        // ���� ������, �������������
                        adapter.CP_Correct_ChangeSeries_InTransaction(connection, transaction,
                            _sessionId, (int)CorrectionReasons.ChangeSeries, _pickListRow.Company,
                            _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                            _changeSeriesControl.Series, _changeSeriesControl.Quantity, confirmEmployeeID);
                        // ���� ������, ������������� (���������� ������)
                        if (_splitChangeSeriesControl.SplitChecked)
                            adapter.CP_Correct_ChangeSeries_InTransaction(connection, transaction,
                                _sessionId, (int)CorrectionReasons.ChangeSeries, _pickListRow.Company,
                                _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                                _splitChangeSeriesControl.Series, _splitChangeSeriesControl.Quantity, confirmEmployeeID);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                // ���� �� ������ �� throw; � ����� �������� ����
                using (SubstandartActsTableAdapter adapter = new SubstandartActsTableAdapter())
                {
                    Data.PickControl.SubstandartActsDataTable table = adapter.GetDataList(_sessionId, _pickListRow.Company,
                                        _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId);
                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (Data.PickControl.SubstandartActsRow row in table.Rows)
                        {
                            Data.PickControl.SubstandartActsDataTable act = new Data.PickControl.SubstandartActsDataTable();
                            act.ImportRow(row);

                            SubstandartActReport report = new SubstandartActReport();
                            Window.WHDocsControlWindow.SubstandartActBarcodePrepare(act);

                            try
                            {
                                report.SetDataSource((DataTable)act);

                                ReportForm form = new ReportForm();
                                form.ReportDocument = report;
                                form.Print();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public object Container { get; set; }

        private void ShowError(string message)
        {
            // MessageBox.Show(message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new ArgumentException(message);
        }

        /// <summary>
        /// �������, ����������� �������� ��������� ����������� ������ �������� ������� �������������
        /// </summary>
        public event EventHandler<DialogResultEnableEventArgs> DialogResultEnableChanged;

        #endregion
    }
}
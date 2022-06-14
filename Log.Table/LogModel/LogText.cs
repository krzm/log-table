using DataToTable;
using Log.Data;

namespace Log.Table;

public abstract class LogToText
    : TextTable<LogModel>
{
	private const string DateTimeFormat1 = "dd.MM.yyyy HH:mm";
	private const string DateTimeFormat2 = "HH:mm";
	
    protected LogToText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<LogModel> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected string GetId(LogModel m) => 
		m.Id.ToString();
	
	protected string GetTask(LogModel m)
    {
        ArgumentNullException.ThrowIfNull(m.Task);
        ArgumentNullException.ThrowIfNull(m.Task.Name);
        return m.Task.Name;
    }

    protected string GetTaskId(LogModel m) => 
		m.TaskId.ToString();

	protected string GetCategory(LogModel m)
    {
        ArgumentNullException.ThrowIfNull(m.Task);
        ArgumentNullException.ThrowIfNull(m.Task.Category);
        ArgumentNullException.ThrowIfNull(m.Task.Category.Name);
        return m.Task.Category.Name;
    }

    protected string GetCategoryId(LogModel m)
    {
        ArgumentNullException.ThrowIfNull(m.Task);
        return m.Task.CategoryId.ToString();
    }

    protected string GetStart(LogModel m) =>
		m.Start.HasValue ?
			m.Start.Value.ToString(DateTimeFormat1) : "";

    protected string GetEnd(LogModel m) => 
		m.End.HasValue ?
			m.End.Value.ToString(DateTimeFormat2) : "";

    protected string GetTime(LogModel m) => 
		$"{m.Time.Hours}:{m.Time.Minutes}";
	
	protected string GetDescription(LogModel m) => 
		string.IsNullOrWhiteSpace(m.Description) == false ?
			m.Description : "";
	
	protected string GetPlace(LogModel m)
    {
        ArgumentNullException.ThrowIfNull(m.Place);
        ArgumentNullException.ThrowIfNull(m.Place.Name);
        return m.Place.Name;
    }
}
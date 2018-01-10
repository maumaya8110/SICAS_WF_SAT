/* variable to hold a trace identifier */ 
DECLARE @trace_id INT   
/* create a trace */ 
EXEC sp_trace_create     @traceid = @trace_id  OUTPUT,    @options =  2,   @tracefile =  N'D:\MSSQL\TRACES\thetrace'
/* get the trace identifier for future use */ 
SELECT @trace_id AS trace_id
GO

DECLARE @on BIT, @tid INT 
SELECT @on=1, @tid = 2

/* add text data column for SQL: BatchCompleted event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 1, @on = @on   
/* add text data column for RPC: completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 1, @on = @on   
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 10, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 10, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 8, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 8, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 18, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 18, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 14, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 14, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 12, @columnid = 13, @on = @on
/* add application name column for SQL: Batch Completed event */ 
EXEC sp_trace_setevent @traceid = @tid,   @eventid = 10, @columnid = 13, @on = @on

/* turn off tracing of application name N'SQL Profiler' */ 
--EXEC sp_trace_setfilter @traceid = @tid,   @columnid = 10, @logical_operator = 1,   @comparison_operator = 7, @value = N'SQL Profiler'
--EXEC sp_trace_setfilter @traceid = @tid,   @columnid = 8, @logical_operator = 1,   @comparison_operator = 0, @value = N'CSCO-SUPERVISIO'
--EXEC sp_trace_setfilter @traceid = @tid,   @columnid = 8, @logical_operator = 1,   @comparison_operator = 0, @value = N'DEVPC'
GO

/* Start the trace, 0 to stop, 2 to delete*/
sp_trace_setstatus 2, 2
GO

DECLARE @hr 		int
DECLARE @ole_FileSystem		int

EXEC @hr = sp_OACreate 'Scripting.FileSystemObject', 
@ole_FileSystem OUT

EXEC @hr = sp_OAMethod @ole_FileSystem, 'DeleteFile', 
     		     NULL, 'D:\MSSQL\TRACES\thetrace.trc'

EXEC @hr = sp_OADestroy @ole_FileSystem

/* Query the trace */
SELECT	TOP 1000 (Duration / 1000000.00) Duration, StartTime, TextData,    ApplicationName,    SPID,    HostName--,    EventClass   
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
--AND		CONVERT(varchar(max),TextData) LIKE '%@Sesion_ID=19610%'
--AND		CONVERT(varchar(max),TextData) LIKE '%EstatusOperativosUnidades%'
AND		HostName NOT IN  ('DEVPC','SICAS')
AND		HostName IN ( 'RUBEN_ADAME' )
AND		StartTime > DATEADD(MINUTE, -60, GETDATE())
--AND		Duration > 10000
ORDER BY Duration DESC



SELECT	HostName, MAX(Duration) Duration
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
AND		StartTime > DATEADD(MINUTE, -60, GETDATE())
AND		HostName NOT IN ( 'DEVPC', 'SICAS' )
--AND		Duration > 10000
GROUP BY HostName
ORDER BY Duration DESC

SELECT	DISTINCT HostName--,    EventClass   
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
AND		StartTime > DATEADD(MINUTE, -3, GETDATE())
AND		HostName <> 'DEVPC'
--AND		Duration > 10000


SELECT	DISTINCT CONVERT(varchar(max),TextData) TextData, MAX(Duration / 1000000.00)  Duration
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
AND		HostName <> 'DEVPC'
AND		Duration >= 1000000
AND		StartTime > '2012-12-04 08:30:00'
GROUP BY	CONVERT(varchar(max),TextData)
ORDER BY	MAX(Duration / 1000000.00) DESC


select Duration, StartTime, TextData,    ApplicationName,    SPID,    HostName
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
where starttime between '2012-11-28 18:11:00' and '2012-11-28 18:14:00'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
order by starttime
where textdata like '%exec sp_executesql N''SELECT * FROM OrdenesTrabajos WHERE OrdenTrabajo_ID = @OrdenTrabajo_ID'',N''@OrdenTrabajo_ID int'',@OrdenTrabajo_ID=65363%'

/*

SELECT	Duration, StartTime, TextData,    ApplicationName,    SPID,    HostName
FROM	Traces.dbo.TraceTable

INSERTS

INSERT	Traces.dbo.TraceTable
SELECT	*
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\thetrace.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
AND		HostName <> 'DEVPC'
AND		Duration > 10000

SELECT	*
INTO	Traces.dbo.TraceTable
FROM :: fn_trace_gettable('D:\MSSQL\TRACES\trace1.trc', DEFAULT)
WHERE	TextData IS NOT NULL
AND		CONVERT(varchar(max),TextData) NOT LIKE '%exec sp_reset_connection%'
AND		CONVERT(varchar(max),TextData) NOT LIKE '%SELECT GETDATE()%'
AND		HostName <> 'DEVPC'
AND		Duration > 10000

*/
select estacion_id, count(*) cont
from	sicassync.dbo.cuentaconductores
group by estacion_id
order by estacion_id
GO

select	estacion_id, count(*) cont
from	sicastest.dbo.cuentaconductores
group by estacion_id
order by estacion_id
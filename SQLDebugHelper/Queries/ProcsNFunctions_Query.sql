select '"' + name + '",'
from sys.objects
where type in ('P', 'TF', 'FN')
and name not like 'dt_%'
and name not in ('max', 'min', 'value')
order by name
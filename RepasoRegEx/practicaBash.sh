#Comandos de la practica SHELL
grep -i 'f' quijote.txt
grep -v '^$' quijote.txt
fgrep '.' quijote.txt
egrep c\{3} quijote.txt
egrep -o '\b(qui|f)\w*' quijote.txt
#Comandos de la practica SED
sed '/s$/!d' quijote.txt
sed '3,5 !d' quijote.txt
sed -i '1i \\tEl quijote\n\t----------\n' quijote.txt
sed 's/[A-Z]/(&)/g' quijote.txt
sed 's/[aeiou]/\U&/g' quijote.txt 
#Comandos de la practica AWK1
w | awk 'NR>2 {print $1}'
awk '{print $1}' quijote.txt
awk '{print $NF}' quijote.txt
awk 'NR % 2 == 1' quijote.txt
awk '{ for (i = NF; i > 0; --i) print $i}' quijote.txt

#  Script para obtener solo las lineas que contienen a pares
#  Se obtiene el numero de lineas del txt
numeroLineas=0
numeroLineas=$(cat quijote.txt | wc -l)
#  Se realliza un for para cada linea
for (( i=1; i<=numeroLineas; i++))
do
	p="p"
	#  Se obtiene el numero de coincidencias para la linea i
	numeroLetras=$(cat quijote.txt | sed -n "${i}p" |egrep -o 'a' | wc -l)
	#  Se realiza un modulo comparado con 0 y si es mayor a 2 la coincidencia
	if ((numeroLetras % 2 == 0 && numeroLetras >= 2))
	then
		#  Se imprime la linea con los caracteres destacados pares
		echo "Linea numero ${i} con numero par de 'a'"
		cat quijote.txt | sed -n "${i}p"
		echo ""
	fi

done

#
BEGIN {
units = "zero one two three four five six seven eight nine"
double = \
"ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteenn"
tens = "twenty thirty fourty fifty"
split(units, spku); split(double, spkd); split(tens, spkt)
# obtain the time
{split($4, time, ":")
# obtain hour of the day (zero .. twenty-three)
if (time[1] < 20) {
if (time[1] < 10) hour = spku[time[1] + 1]
else hour = spkd[time[1] -10] +11}
else {
if ((time[1] % 10) < 1) hour = spkt[int(time[1] / 10) -1]
else hour = spkt[int(time[1] / 10) -1]1 " " spku[(time[1] % 10) + 1]}
# obtain minutes of the hour (zero fifty-nine)
if (time[2] < 20) {
if (time[2] < 10) minute = spku[time[2] +1]
else minute = spkd[(time[2] -10) +1]}
else {
if ((time[2] % 10) < 1) minute = spkt[int(time[2] / 10) -1]
else minute = spkt[int(time[2] / 10) -1] " " spku[(time[2] % 10) + 1]}
# obtain seconds of the minute (zero fifty-nine)
if (time[3] < 20) {
if (time[3] < 10) second = spku[time[3] + 1]
else second = spkd[(time[3] -10) + 1 ]}
else {
if ((time[3] % 10) < 1) second = spkt[int(time[3] / 10) -1]
else second = spkt[int(time[3] / 10) -1] " " spku[int(time[3] % 10) + 1]}
}
}
END {
printf "La Hora es \n"
printf "%s horas %s minutos y %s segundos exactamente\n",hour,minute,second
}



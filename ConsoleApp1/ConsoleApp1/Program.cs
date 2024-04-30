

using System.Text;

internal class Program

{
    private static void Main(string[] args)
    {
        const string ADD_TEXT_TO_DIALOG = ". Нажмите любую клавишу...";
        var _anyNumber = default(int);
       
        while (true) {
            Console.WriteLine("Введите целочисленное значение, для выхода введите не число: ");
            
            if (!((int.TryParse(Console.ReadLine(),out _anyNumber))))
            {
                Console.WriteLine("Не число, программа завершена!");
                break;
            }

            Console.WriteLine(new StringBuilder($"{(IsPolyMath(ref _anyNumber) ? "Полиндром" : "Не полиндром")}").Append(ADD_TEXT_TO_DIALOG));
            Console.ReadKey();
            Console.Clear();
        }
    }

    /// <summary>
    /// Метод определяет является ли число полиндромом.
    /// </summary>
    /// <param name="Number">Число проверяемое на полиндром</param>
    /// <returns>Возвращает истину, если число полиндром, иначе - ложь</returns>
    private static bool IsPolyMath(ref readonly int Number)
    {
        /*Чтобы не запускать лишний раз цикл while при вводе отрицательного значения*/
        if (Number < 0) return false;

        /*Определение полиндрома: "реверс и не отрицательно", значит 0-9 - полиндромы*/
        if (Number < 10) return true;
        
        /*Далее определяем плолендромы с числами больше 9 */
        var _temp = Number;             
        var _reversed = default(int);   

        while (_temp > 0)
        {
            _reversed = _reversed * 10 + _temp % 10;
            _temp /= 10;
        }
        return _reversed == Number;
    }
}
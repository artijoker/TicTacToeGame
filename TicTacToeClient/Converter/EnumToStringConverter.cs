using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TicTacToeLibrary;

namespace TicTacToeClient {
    class EnumToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return null;
            if (!(value is Sign || value is GameStatus)) {
                if (!(value is Sign))
                    throw new ArgumentException($"Исходное значение должно иметь тип Sign");
                else
                    throw new ArgumentException($"Исходное значение должно иметь тип GameStatus");
            }
            if (targetType != typeof(string))
                throw new InvalidCastException();

            if (value is Sign) {
                Sign sign = (Sign)value;
                if (sign == Sign.Сross) return "Крестики";
                else if (sign == Sign.Zero) return "Нолики";
                else return "";
            }
            else {
                GameStatus gameStatus = (GameStatus)value;
                if (gameStatus == GameStatus.GameIsOn) return "Игра идёт";
                else if(gameStatus == GameStatus.CrossVictory) return "Игра завершена победой крестиков";
                else if(gameStatus == GameStatus.ZeroVictory) return "Игра завершена победой ноликов";
                else if(gameStatus == GameStatus.Draw) return "Игра завершена ничьей";
                else return "Игра ещё не началась";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}

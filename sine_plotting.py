import csv
import matplotlib.pyplot as plt
import numpy


def get_values(filename: str) -> list[list]:

    x_values = []
    y_values = []

    with open(filename, 'r') as values_file:
        reader = csv.reader(values_file, delimiter=';')
        for row in reader:
            x_values.append(float(row[0]))
            y_values.append(float(row[1]))

    return [x_values, y_values]

chebyshes_values = get_values("E:\Studying\SCM_Coursework\Methods\chebyshev.csv")
taylor_values = get_values("E:\Studying\SCM_Coursework\Methods\\taylor.csv")
math_sin_values = get_values("E:\Studying\SCM_Coursework\Methods\lib.csv")

chebyshev_error = get_values("E:\Studying\SCM_Coursework\Methods\chebyshev_errors.csv")
taylor_error = get_values("E:\Studying\SCM_Coursework\Methods\\taylor_errors.csv")

figure, plots = plt.subplots(3, 2)

chebyshev_plot = plots[0, 0]
taylor_plot = plots[1, 0]
library_plot = plots[2, 0]

chebyshev_error_plot = plots[0, 1]
taylor_error_plot = plots[1, 1]

chebyshev_plot.grid()
chebyshev_plot.set_title("Chebyshev")


taylor_plot.grid()
taylor_plot.set_title("Taylor")


library_plot.grid()
library_plot.set_title("Library")


chebyshev_error_plot.grid()
chebyshev_error_plot.set_title("Chebyshev error")

taylor_error_plot.grid()
taylor_error_plot.set_title("Taylor error")

chebyshev_plot.plot(chebyshes_values[0], chebyshes_values[1], label="Chebyshev coefficients", color="green")
taylor_plot.plot(taylor_values[0], taylor_values[1], label="Taylor series", color="red")
library_plot.plot(math_sin_values[0], math_sin_values[1], label="Built-in sin(x) function", color="blue")

#chebyshev_plot.xlabel("Degrees (radian)")
#chebyshev_plot.ylabel("Sin(x)")
#taylor_plot.xlabel("Degrees (radian)")
#taylor_plot.ylabel("Sin(x)")
#library_plot.xlabel("Degrees (radian)")
#library_plot.ylabel("Sin(x)")

#values.legend(fontsize=10)

#plots[0, 1].grid()
chebyshev_error_plot.plot(chebyshev_error[0], chebyshev_error[1], label='Chebyshev error', color="green")
taylor_error_plot.plot(taylor_error[0], taylor_error[1], label='Taylor error', color="red")
#plots[2, 1].plot(0, 0, label='Taylor error')
#errors.xlabel('Degrees (radian)')
#errors.ylabel("Error")
#errors.legend(fontsize=10)

plt.show()


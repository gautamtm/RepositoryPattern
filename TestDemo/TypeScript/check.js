var Demo;
(function (Demo) {
    var Employee = (function () {
        function Employee(empID, name) {
            this.id = empID;
            this.name = name;
        }
        Employee.prototype.getID = function () {
            return "Employee ID: " + this.id;
        };
        Employee.prototype.replyToText = function (typeValue) {
            return "You have type " + typeValue;
        };
        Employee.prototype.ajaxRequest = function (url, type, data) {
            var request = $.ajax({
                type: type,
                url: url,
                data: data,
                dataType: "json"
            });
        };
        return Employee;
    })();
    Demo.Employee = Employee;

    var employee = new Employee(1, "ram");
})(Demo || (Demo = {}));
//# sourceMappingURL=check.js.map

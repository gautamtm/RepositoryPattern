module Demo {
    export  class Employee {
        id: number;
        name: string;
        constructor(empID: number, name: string) {
            this.id = empID;
            this.name = name;
        }

        getID() {
            return "Employee ID: " + this.id;
        }
        replyToText(typeValue: string) {
            return "You have type " + typeValue;
        }
        ajaxRequest(url: string, type: string, data: any)
        {
            var request = $.ajax({
                type: type,
                url: url,
                data: data,
                dataType: "json"
            });
        }
}

    var employee = new Employee(1, "ram");
    //let employee = new Employee(1, "ram");
    ////console.log((employee.replyToText(3)));

    //let input = document.createElement('input');
    //let button = document.createElement('button');
    //button.textContent = "Submit";
    //button.onclick = function () {
    //    alert(employee.replyToText(input.value));
    //}

    //document.body.appendChild(input);
    //document.body.appendChild(button);
}
export interface IEmployeeDTO {
    name: string;
    salary: string;
    address: { fulladdress: string, appartmentnumber: number }
    id: number | undefined;
}
export class EmployeeDTO implements IEmployeeDTO {
    name: string; salary: string;
    address: { fulladdress: string; appartmentnumber: number; };
    id: number;

    constructor(data?: IEmployeeDTO) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.name = data["name"];
            this.id = data["id"];
            this.salary = data["salary"];
            this.address = data["address"];
        }
    }

    static fromJS(data: any): EmployeeDTO {
        data = typeof data === 'object' ? data : {};
        let result = new EmployeeDTO();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["salary"] = this.salary;
        data["address"] = this.address;
        data["id"] = this.id;
        return data;
    }

    clone(): EmployeeDTO {
        const json = this.toJSON();
        let result = new EmployeeDTO();
        result.init(json);
        return result;
    }
}
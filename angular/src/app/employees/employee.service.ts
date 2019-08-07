import { HttpClient } from "@angular/common/http";
import { Optional, Inject, Injectable } from "@angular/core";
import { API_BASE_URL } from "@shared/service-proxies/service-proxies";
import { Observable } from "rxjs";

@Injectable()
export class EmployeeService {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;
    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    getAll(page: number): Observable<any> {
        let url = this.baseUrl + "/api/services/app/Employee/GetAll?MaxResultCount=10&SkipCount=" + (0 * page);
        console.log(url);
        return this.http.request("get", url)
    }
}
// Angular
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

// Environment
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root',
})

export class CommonService {
    SERVER_URL: string = environment.backendApi;

    constructor(private httpClient: HttpClient) { }

    private createCompleteRoute(route: string, envAddress: string) {
        return `${envAddress}/${route}`;
    }

    private generateHeaders() {
        return {
            headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache' }),
        };
    }

    public getData(route: string) {
        return this.httpClient.get(
            this.createCompleteRoute(route, this.SERVER_URL), this.generateHeaders()
        );
    }

    public create(route: string, body) {
        return this.httpClient.post(
            this.createCompleteRoute(route, this.SERVER_URL),
            body,
            this.generateHeaders()
        );
    }

    public update(route: string, body) {
        return this.httpClient.put(
            this.createCompleteRoute(route, this.SERVER_URL),
            body,
            this.generateHeaders()
        );
    }

    public delete(route: string) {
        return this.httpClient.delete(
            this.createCompleteRoute(route, this.SERVER_URL)
        );
    }
}
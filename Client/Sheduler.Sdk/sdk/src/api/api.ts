import { paths } from "./openapi.js";
import type { Schedule } from "../types";

export class Api {
    constructor(private baseUrl: string) {
    }
    public getAll(){
        return this.fetch<Schedule[]>("/Schedules", {
            method: "GET",
        })
    }
    public get(id: string){
        return this.fetch<Schedule>("/Schedules/{id}", {
            method: "GET",
            params: { id }
        })
    }

    public add(schedule: Schedule){
        return this.fetch<void>("/Schedules", {
            method: "POST",
            body: JSON.stringify(schedule)
        });
    }

    private async fetch<T>(path: keyof paths, options: RequestInit & {
        params?: Record<string, string | number>,
    }): Promise<T> {
        let url = path as string;
        if (options.params){
            for (let key in options.params) {
                url = url.replace(`{${key}}`, options.params[key].toString());
            }
        }
        const response = await fetch(this.baseUrl + url, {
            ...options,
            headers: {
                ...options.headers,
                'Content-Type': 'application/json'
            }
        });
        if (response.ok) {
            if (response.status == 204)
                return undefined as T;
            return await response.json() as T;
        } else {
            throw new Error(await response.text());
        }
    }
}

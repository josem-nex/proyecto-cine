import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class AuxiliarService {
    strToBool(str: string): boolean { return str.toLowerCase() === 'true'; }
    boolTostr(bool: boolean): string { return (bool) ? 'true' : 'false'; }
}
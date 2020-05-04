export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    cnp: string;
    created: Date;
    city: string;
    address: string;
    zipCode: string;
    creditScore?: number;
}

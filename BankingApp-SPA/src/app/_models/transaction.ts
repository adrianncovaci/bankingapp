export interface Transaction {
    dateIssued: Date;
    amount: number;
    message: string;
    transactionType: string;
    receiverAccountId?: number;
    receiverCustomerName?: number;  
}

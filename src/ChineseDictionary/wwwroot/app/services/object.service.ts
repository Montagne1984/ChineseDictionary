export abstract class ObjectService<T> {
    abstract get(): Promise<T[]>;

    protected handleError(error: any) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}
export interface LoginRegisterResponse {
    token: string
}

export interface ApiResult<TResponse> {
    result?: T | null,
    failure?: boolean
    errors?: { [key: string]: string } | null
}
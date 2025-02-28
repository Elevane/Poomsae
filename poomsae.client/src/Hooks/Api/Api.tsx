import { message } from "antd"
import ContentType from "./ContentType";
import { ApiResult } from "../../Models/ApiResult";

interface RequestOptions {
    method: string;
    headers: HeadersInit;
    body?: string | FormData | null;
}

async function request<T>(
    method: string,
    route: string,
    content?: object | null,
    contentType: ContentType = ContentType.json,
    token?: string
): Promise<ApiResult<TResponse>> {
    const header: HeadersInit = {
        "Access-Control-Allow-Origin": "*",
        Accept: "*/*",
        "xapikey": `${import.meta.env.VITE_APP_API_KEY}`,
    }
    if (token) {
        header.Authorization = `Bearer ${token}`;
    }

    if (contentType !== ContentType.media) {
        header["content-type"] = `${contentType}`;
    }
    const options: RequestOptions = {
        method: method,
        headers: header,
    };

    if (content !== null && content !== undefined) {
        if (contentType === ContentType.media) {
            options.body = content as FormData;
        } else {
            options.body = JSON.stringify(content);
        }
    }

    try {
        const response = await fetch(route, options)
        const apiResult = (await response.json()) as ApiResult<TResponse>
        if (apiResult.errors) {
            return {
                result: null,
                failure: true,
                errors: apiResult.errors,
            } as ApiResult<TResponse>
        }

        return {
            result: apiResult.result,
            failure: false,
            errors: null,
        }
    } catch (error) {
        message.error("Error lors de l'appel au server.")
        return {
            result: null,
            failure: true,
            errors: null,
        }
    }
}

async function post<T>(
    route: string,
    content: object,
    contentType?: ContentType,
    token?: string
): Promise<ApiResult<TResponse>> {
    return await request("POST", route, content, contentType, token)
}
async function get<T>(
    route: string,
    content?: object | null,
    contentType?: ContentType,
    token?: string
): Promise<ApiResult<TResponse>> {
    return await request("GET", route, content, contentType, token)
}

async function patch<T>(
    route: string,
    content?: object | null,
    contentType?: ContentType,
    token?: string
): Promise<ApiResult<TResponse>> {
    return await request("PATCH", route, content, contentType, token)
}

async function del<T>(
    route: string,
    content?: object | null,
    contentType?: ContentType,
    token?: string
): Promise<ApiResult<TResponse>> {
    return await request("DELETE", route, content, contentType, token)
}

const api = { post, get, patch, del }
export default api
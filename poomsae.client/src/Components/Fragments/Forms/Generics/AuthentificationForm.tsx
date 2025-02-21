import { Form, FormInstance } from "antd"
import { ReactNode } from "react"

export interface AuthentificationFormProps<T> {
    children: ReactNode,
    onFinish: (e: T) => Promise<void>,
    form: FormInstance<T>
}

const AuthentificationForm = <T,>({ children, form, onFinish }: AuthentificationFormProps<T>) => {
    return (
        <Form form={form} layout="horizontal" onFinish={onFinish} style={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>{children}</Form>
    )
}
export default AuthentificationForm
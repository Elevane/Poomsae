import { Form, Input } from "antd"

export interface EmailFormItemProps {
    required?: boolean
    message?: string
    autoComplete?: string
    placeHolder?: string
}

const EmailFormItem: React.FC<EmailFormItemProps> = ({ required, message, autoComplete, placeHolder }) => {
    const baseStyle: React.CSSProperties = {
        width: "300px",
        height: "40px",
        borderRadius: 0
    }

    return (
        <Form.Item
            name="email"
            rules={[{ required: required ?? true, message: message ?? "Enter an email" }]}>
            <Input type="text" autoComplete={autoComplete ?? "off"} placeholder={placeHolder ?? "texte"} style={baseStyle} />
        </Form.Item>
    )
}

export default EmailFormItem
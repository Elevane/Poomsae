import { Form, Input } from "antd"

export interface PasswordFormItemProps {
    name?: string
    label?: string
    autoComplete?: string
    placeHolder?: string
}

const PasswordFormItem: React.FC<PasswordFormItemProps> = ({ name, label, autoComplete, placeHolder }) => {
    const baseStyle: React.CSSProperties = {
        width: "300px",
        height: "40px",
        borderRadius: 0
    }

    return (<Form.Item
        name={name ?? "password"}
        label={label ?? null}
        rules={[{ required: true, message: "Enter an Password" }]}
    >
        <Input.Password type="password" autoComplete={autoComplete ?? "current-password"} placeholder={placeHolder ?? "password"} style={baseStyle} />
    </Form.Item>)
}

export default PasswordFormItem
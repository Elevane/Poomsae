import { Form, Input } from "antd"

export interface ConfirmEmailFormItemProps {
    reference?: string
    label?: string
    autoComplete?: string
    placeHolder?: string
}

const ConfirmPasswordFormItem: React.FC<ConfirmEmailFormItemProps> = ({ reference, label, autoComplete, placeHolder }) => {
    const baseStyle: React.CSSProperties = {
        width: "300px",
        height: "40px",
        borderRadius: 0
    }
    return (<Form.Item
        name={"confirmPassword"}
        label={label ?? null}
        rules={[
            {
                required: true,
            },
            ({ getFieldValue }) => ({
                validator(_, value) {
                    if (!value || getFieldValue(reference ?? 'password') === value) {
                        return Promise.resolve();
                    }
                    return Promise.reject(new Error('Passwords do no match'));
                },
            }),
        ]}
    >
        <Input.Password type="password" autoComplete={autoComplete ?? "current-password"} placeholder={placeHolder ?? "password"} style={baseStyle} />
    </Form.Item>)
}

export default ConfirmPasswordFormItem
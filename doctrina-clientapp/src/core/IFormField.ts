export interface IForm{
    FORM_FIELDS: IFormField[]
}



interface IFormField{
    NAME: string
    ID: string
    LABEL: string
    FORM_FIELD: any
    TYPE: string
    VALUE: string
    IS_VALID: boolean
    IS_TOUCHED: boolean
    ERROR?: string
    VALIDATIONS?: IFormFieldValidations[]
}

interface IFormFieldValidations{
    REGEX: string
    MATCH_RESULT?: boolean    
    ERROR_MESSAGE: string
}

export function validateFromField(formField: IFormField){

    let fieldValidations = formField.VALIDATIONS

    let isFieldValid = false;

    fieldValidations?.map(validation => {
      if(!new RegExp(validation.REGEX).test(formField.VALUE)){        
        formField.IS_VALID = false
        formField.ERROR = validation.ERROR_MESSAGE                        
      }
      else{
        isFieldValid = true
      }
    })

    if(isFieldValid){
        formField.IS_VALID = true
        formField.ERROR = ""
    }
}

export default IFormField
public class Solution {
    public string NumberToWords(int num) {  

        string output = "";
        Dictionary<int, string[]> names = new Dictionary<int, string[]>(10){
            {0, ["Zero", "Ten", "Ten"]},
            {1, ["One", "Ten", "Eleven"]},
            {2, ["Two", "Twenty", "Twelve"]},
            {3, ["Three", "Thirty", "Thirteen"]},
            {4, ["Four", "Forty", "Fourteen"]},
            {5, ["Five", "Fifty", "Fifteen"]},
            {6, ["Six", "Sixty", "Sixteen"]},
            {7, ["Seven", "Seventy", "Seventeen"]},
            {8, ["Eight", "Eighty", "Eighteen"]},
            {9, ["Nine", "Ninety", "Nineteen"]}
        };  // 0th index = digit form, 1st index = x10 form, 2nd index = teen form

        string chars = Convert.ToString(num);
        while(chars.Length < 10){
            chars = "_" + chars;
        }
        bool stringFound = false;
        bool addMillion = true;
        if(num > 100000000){
            if(Convert.ToInt32(chars.Substring(1,3)) == 0){
                addMillion = false;
            }
        }
        bool addThousand = true;
        if(num > 100000){
            if(Convert.ToInt32(chars.Substring(4,3)) == 0){
                addThousand = false;
            }
        }
        for(int i = 0; i < chars.Length; i++){
            if(!stringFound){
                if(chars[i] != '_'){
                    switch(chars.Length - i){
                        case 10:    // 1,000,000,000 = billion
                            if(chars[i] != '0'){
                                output += names[chars[i] - '0'][0] + " Billion ";
                                if(Convert.ToInt32(chars.Substring(i+1)) == 0){
                                    stringFound = true;
                                }
                            }
                            break;
                        case 9:     // 0,100,000,000 = hundred million
                            if(chars[i] != '0'){
                                output += names[chars[i] - '0'][0] + " Hundred ";
                            }
                            break;
                        case 8:     // 0,010,000,000 = ten, eleven, twelve, twenty million
                            if(chars[i] != '0'){
                                if(chars[i] == '1'){
                                    output += names[chars[i+1] - '0'][2] + " ";    // teens
                                }
                                else{
                                    output += names[chars[i] - '0'][1] + " ";    // tens
                                }
                            }
                            break;
                        case 7:     // 0,001,000,000 = million
                            if(chars[i] != '0'){
                                if(chars[i-1] == '0' || chars[i-1] != '1'){
                                    output += names[chars[i] - '0'][0] + " ";
                                }
                            }
                            if(Convert.ToInt32(chars.Substring(i+1)) == 0){
                                stringFound = true;
                            }
                            if(addMillion){
                                output = output.Trim() + " Million ";
                            }
                            break;
                        case 6:     // 0,000,100,000 = hundred thousand
                            if(chars[i] != '0'){
                                output += names[chars[i] - '0'][0] + " Hundred ";
                                /*
                                if(chars[i+1] == '0' && chars[i+2] == '0'){
                                    output += "Thousand ";
                                }
                                */
                            }
                            break;
                        case 5:     // 0,000,010,000 = ten thousand
                            if(chars[i] != '0'){
                                // we need to cover if the form _12,000 ; 204,000 ; _40,000 ; _23,000
                                //                              teens     no te(e)n  tens       tens
                                
                                if(chars[i] == '1'){
                                    output += names[chars[i+1] - '0'][2] + " ";    // teens
                                }
                                else{
                                    output += names[chars[i] - '0'][1] + " ";    // tens
                                }

                            }
                            break;
                        case 4:     // 0,000,001,000 = thousand
                            if(chars[i] != '0'){
                                
                                if(chars[i-1] == '0' || chars[i-1] != '1'){
                                    output += names[chars[i] - '0'][0] + " ";
                                }
                                
                            }
                            else{
                                if(Convert.ToInt32(chars.Substring(i+1)) == 0){
                                    stringFound = true;
                                }
                            }
                            if(addThousand){
                                output += "Thousand ";
                            }
                            break;
                        case 3:     // 0,000,000,100 = hundred
                            if(chars[i] != '0'){
                                output += names[chars[i] - '0'][0] + " Hundred ";
                            }
                            break;
                        case 2:     // 0,000,000,010 = ten
                            if(chars[i] != '0'){
                                if(chars[i] == '1'){
                                    output += names[chars[i+1] - '0'][2] + " ";    // teens
                                }
                                else{
                                    output += names[chars[i] - '0'][1] + " ";    // tens
                                }
                            }
                            break;
                        default:    // 0,000,000,001 = one
                            if((chars[i] != '0' || num == 0) && chars[i-1] != '1'){
                                output += names[chars[i] - '0'][0];
                            }
                            stringFound = true;
                            break;
                    }
                }
            }
            }
            
        return output.Trim();
    }
}
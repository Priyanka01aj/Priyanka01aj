function findOccurrences(name: string): void {
  name = "Priyanka Ajmera";
  var count: { [key: string]: number } = {};
  for (var char of name.toLowerCase()) {
        count[char] = (count[char] || 0) + 1;
  }
  for (var char in count) {
    if(char===" ") continue;

    console.log("ocuurance",char + " : " + count[char]);
  }
  // for (let i = 0; i < name.length; i++) {
  //   if (name[i] === ' ') continue;
  //   let occur = 1;
  //   for (let j = i+1; j < name.length; j++) {
  //     if (name[i] === name[j]) {
  //       occur++;
  //     }
  //   }
  //   console.log(name[i], occur);
  // }

}

function findIndex(name: string, char: string) {
  console.log("index of",char);
  console.log(name.indexOf(char));
}

// Finding first unique character in a string(char that does not repeat in string)
function uniqueChar(name: string) {
  name = "Rajesh Ajmera";
  var count: { [key: string]: number } = {};
  for (const char of name.toLowerCase()) {
    count[char] = (count[char] || 0) + 1;
  }
  for (const ch of name) {
    if (count[ch] === 1) {
      console.log("unique char",ch);
      return;
    }
  }
}

function groupAnagram(listName:string[]){
  const anagramMap = new Map<string, string[]>();

  for(let name of listName){
    const sortedKey = name.split("").sort().join("");
    if(!anagramMap.has(sortedKey)){
      anagramMap.set(sortedKey,[]);
    }
    anagramMap.get(sortedKey)?.push(name);
  }
 return Array.from(anagramMap.values());
}

function LengthOfLastWord(){
let fullName = "Priyanka Ajmera";
let i=0;
let lastWordLength=fullName.length-1;

while(i>=0 && fullName[lastWordLength] !== " "){
  i++;
  lastWordLength--;
}

  console.log(i++);
}

function removeDuplicates<T>(arr:T[]):T[]{
 return [...new Set(arr)]

 }

findOccurrences("Priyanka Ajmera");
findIndex("Priyanka Ajmera","y");
uniqueChar("Rajesh Ajmera");
console.log(groupAnagram(["eat", "tea", "tan", "ate", "nat", "bat"]))
LengthOfLastWord();
console.log(removeDuplicates(["Priyanka","Priyanka","Rajesh"]))


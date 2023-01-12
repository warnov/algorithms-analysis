use std::io;

fn main() {
    let mut input = String::new();
    io::stdin().read_line(&mut input);
    let mut t: u16 = input.trim().parse().unwrap();
    let mut result = String::new();
    while t > 0 {       
        input.clear();
        io::stdin().read_line(&mut input);
        let mut a = input.trim().parse::<u64>().unwrap();
        while a % 2 == 0 {a/=2};
        if a == 1 {
            result.push_str("NO\n");
        } else {
            result.push_str("YES\n");
        }
        t -= 1;
    };
    print!("{}", result);    
}
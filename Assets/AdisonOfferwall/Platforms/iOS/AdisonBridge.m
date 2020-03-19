#import <AdisonOfferwallSDK/AdisonOfferwallSDK-Swift.h>

/// Returns an NSString copying the characters from |bytes|, a C array of UTF8-encoded bytes.
/// Returns nil if |bytes| is NULL.
static NSString *GADUStringFromUTF8String(const char *bytes) { return bytes ? @(bytes) : nil; }

typedef void (*OnOfferwallOpenCallback)();
typedef void (*OnOfferwallClosedCallback)();

OnOfferwallOpenCallback offerwallOpenCallback = NULL;
OnOfferwallClosedCallback offerwallClosedCallback = NULL;

@interface LifeCycleDelegateBridge: NSObject<LifeCycleDelegate>
@end
static LifeCycleDelegateBridge *__delegate = nil;

/// Returns a C string from a C array of UTF8-encoded bytes.
static const char *cStringCopy(const char *string) {
  if (!string) {
    return NULL;
  }
  char *res = (char *)malloc(strlen(string) + 1);
  strcpy(res, string);
  return res;
}

/// Returns a C string from a C array of UTF8-encoded bytes.
static const char **cStringArrayCopy(NSArray *array) {
  if (array == nil) {
    return nil;
  }

  const char **stringArray;

  stringArray = calloc(array.count, sizeof(char *));
  for (int i = 0; i < array.count; i++) {
    stringArray[i] = cStringCopy([array[i] UTF8String]);
  }
  return stringArray;
}

void __initialize(const char *appKey) {
    [[Adison shared] initializeWith:GADUStringFromUTF8String(appKey)];
}

void __setDebugEnabled(bool enable) {
    // do nothing yet
}

void __setUid(const char *uid) {
    [[Adison shared] setUid:GADUStringFromUTF8String(uid)];
}

const char* __getUid() {
    NSString *uid = [Adison shared].uid;
    return [uid UTF8String];
}

void __setIsTester(bool enable) {
    [[Adison shared] isTester:enable];
}

void __setServer(int env) {
    if (env == 0) {
        [[Adison shared] setServer:StageDevelopment];
    } else if (env == 1) {
        [[Adison shared] setServer:StageStaging];
    } else if (env == 2) {
        [[Adison shared] setServer:StageProduction];
    }
}

void __setBirthYear(int birthYear) {
    [[Adison shared] setBirthYear:birthYear];
}

void __setGender(int gender) {
 if (gender == 0) {
     [[Adison shared] setGender:GenderUnknown];
 } else if (gender == 1) {
     [[Adison shared] setGender:GenderMale];
 } else if (gender == 2) {
     [[Adison shared] setGender:GenderFemale];
 }
}

void __showOfferwall() {
    UIViewController* viewController = UnityGetGLViewController();
    [[Adison shared] presentOfferwall:viewController adId:nil animated:NO completion:nil];
}

void __setLifeCycleCallbacks(OnOfferwallOpenCallback _offerwallOpenCallback, OnOfferwallClosedCallback _offerwallClosedCallback) {
    printf("__setLifeCycleDelegate");
    if (!__delegate) {
        __delegate = [[LifeCycleDelegateBridge alloc] init];
    }
    [[Adison shared] setLifeCycleDelegate:__delegate];
    offerwallOpenCallback = _offerwallOpenCallback;
    offerwallClosedCallback = _offerwallClosedCallback;
}

//CFTypeRef __setLifeCycleDelegate(LifeCycleDelegate *delegate) {
//    [Adison shared].delegate = delegate
//    return CFBridgingRetain([[Adison shared]]);
//}
//
//


void __setConfig(AdisonConfig *config) {
    [[Adison shared] setConfig:config];
}

CFTypeRef __createAdisonConfig() {
    return CFBridgingRetain([[AdisonConfig alloc] init]);
}

void __setOfferwallListTitle(AdisonConfig *config, const char *title) {
    if (config != NULL) {
        config.offerwallListTitle = GADUStringFromUTF8String(title);
    }
}

void __isPrepareViewHidden(AdisonConfig *config, bool hidden) {
    if (config != NULL) {
        config.prepareViewHidden = hidden;
    }
}

void __setColorScheme(AdisonColorScheme *colorScheme) {
    [[Adison shared] setColorScheme:colorScheme];
}

CFTypeRef __createAdisonColorScheme() {
    return CFBridgingRetain([[AdisonColorScheme alloc] init]);
}

void __setPrimaryColor(AdisonColorScheme *colorScheme, const char *hexString) {
    if (colorScheme != NULL) {
        unsigned rgbValue = 0;
        NSScanner *scanner = [NSScanner scannerWithString:GADUStringFromUTF8String(hexString)];
        [scanner setScanLocation:1]; // bypass '#' character
        [scanner scanHexInt:&rgbValue];
        colorScheme.primaryColor = [UIColor colorWithRed:((rgbValue & 0xFF0000) >> 16)/255.0 green:((rgbValue & 0xFF00) >> 8)/255.0 blue:(rgbValue & 0xFF)/255.0 alpha:1.0];
    }
}

void __setPrimaryColorVariant(AdisonColorScheme *colorScheme, const char *hexString) {
    if (colorScheme != NULL) {
        unsigned rgbValue = 0;
        NSScanner *scanner = [NSScanner scannerWithString:GADUStringFromUTF8String(hexString)];
        [scanner setScanLocation:1]; // bypass '#' character
        [scanner scanHexInt:&rgbValue];
        colorScheme.primaryColorVariant = [UIColor colorWithRed:((rgbValue & 0xFF0000) >> 16)/255.0 green:((rgbValue & 0xFF00) >> 8)/255.0 blue:(rgbValue & 0xFF)/255.0 alpha:1.0];
    }
}

void __setOnPrimaryColor(AdisonColorScheme *colorScheme, const char *hexString) {
    if (colorScheme != NULL) {
        unsigned rgbValue = 0;
        NSScanner *scanner = [NSScanner scannerWithString:GADUStringFromUTF8String(hexString)];
        [scanner setScanLocation:1]; // bypass '#' character
        [scanner scanHexInt:&rgbValue];
        colorScheme.onPrimaryColor = [UIColor colorWithRed:((rgbValue & 0xFF0000) >> 16)/255.0 green:((rgbValue & 0xFF00) >> 8)/255.0 blue:(rgbValue & 0xFF)/255.0 alpha:1.0];
    }
}

@implementation LifeCycleDelegateBridge

- (void)offerwallOpen {
    if (offerwallOpenCallback != NULL) {
        offerwallOpenCallback();
    }
}

- (void)offerwallClosed {
    if (offerwallClosedCallback != NULL) {
        offerwallClosedCallback();
    }
}

@end

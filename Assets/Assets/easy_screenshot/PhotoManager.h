//
//  PhotoManager.h
//  Unity-iPhone
//
//  Created by epoching on 2018/6/14.
//

#import <Foundation/Foundation.h>

@interface PhotoManager : NSObject
- ( void ) imageSaved: ( UIImage *) image didFinishSavingWithError:( NSError *)error
          contextInfo: ( void *) contextInfo;
@end
